using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.APIHandler;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiHandler _apiHandler;

        public ProductController(IApiHandler apiHandler, IConfiguration configuration)
        {
            _apiHandler = apiHandler;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string ProductUrl = _configuration["BaseURL"] + UrlStrings.GetAllProduct;
           
            ProductVM product = new ProductVM();

            var productList = _apiHandler.GetApi<CustomResponseDto<List<ProductDto>>>(ProductUrl);
            product.ProductDtos = productList.Data;
             
            return View(product);
        }
        public IActionResult AddProductPage()
        {
            string BrandUrl = _configuration["BaseURL"] + UrlStrings.GetAllBrand;
            string CategoryUrl = _configuration["BaseURL"] + UrlStrings.GetAllCategory;
            ProductVM product = new ProductVM();
            var brandList = _apiHandler.GetApi<CustomResponseDto<List<BrandDto>>>(BrandUrl);
            var categoryList = _apiHandler.GetApi<CustomResponseDto<List<CategoryDto>>>(CategoryUrl);
            product.CategoryDtos = categoryList.Data;
            product.BrandDtos = brandList.Data;
            return View(product);
        }

        [HttpPost]    
        public JsonResult AddProduct(AddProductDto addProduct)
        {
            var companyId = HttpContext.Request.Cookies["MemberId"];
            addProduct.CompanyId = Convert.ToInt32(companyId);
            string url = _configuration["BaseURL"] + UrlStrings.AddProduct;
            var post = _apiHandler.PostApiString(addProduct, url);
            return Json(new { success = true });
        }
        public IActionResult ProductFeatures(int productId)
        {
            string url = _configuration["BaseURL"] + UrlStrings.GetProductFeatures + productId;
            var getList = _apiHandler.GetApi<CustomResponseDto<List<ProductFeaturesDto>>>(url);
            return View(getList.Data);
        }
        public JsonResult AddProductFeature(AddProductFeatureDto addProductFeature)
        {
            string url = _configuration["BaseURL"] + UrlStrings.AddProductFeature;
            var post = _apiHandler.PostApiString(addProductFeature, url);
            return Json(new { success = true });
        }
        public IActionResult DiscountList(int featureId)
        {
            string url = _configuration["BaseURL"] + UrlStrings.GetFeatureDiscount + featureId;
            var get = _apiHandler.GetApi<CustomResponseDto<List<DiscountDto>>>(url);
            ViewBag.featureId= featureId;
            return View(get.Data);
        }
        public JsonResult AddDiscount(AddDiscountDto addDiscount)
        {
            string url = _configuration["BaseURL"] + UrlStrings.AddDiscoutnt;
            var post = _apiHandler.PostApiString(addDiscount, url);
            return Json(new { success = true });
        }
        public JsonResult AddToBasket(int ProductId)
        {
            var companyId = Convert.ToInt32(HttpContext.Request.Cookies["MemberId"]);
            AddBasketDto addBasketDto = new AddBasketDto() { ProductId = ProductId, MemberId = companyId };
            string url = _configuration["BaseURL"] + UrlStrings.AddBasket;
            var post = _apiHandler.PostApiString(addBasketDto, url);
            return Json(new { success = true });
        }
        public IActionResult Basket()
        {
            var companyId = Convert.ToInt32(HttpContext.Request.Cookies["MemberId"]);
            string url = _configuration["BaseURL"] + UrlStrings.GetMemberBasket + companyId;
            var getList = _apiHandler.GetApi<CustomResponseDto<List<BasketDto>>>(url);
            return View(getList.Data);
        }
        public JsonResult PurchaseAll()
        {
            var companyId = Convert.ToInt32(HttpContext.Request.Cookies["MemberId"]);
            string url = _configuration["BaseURL"] + UrlStrings.PurcheseAll + companyId;
            var get = _apiHandler.GetApi<CustomResponseDto<BasketDto>>(url);
            return Json(new { success = true });
        }
    }
}
