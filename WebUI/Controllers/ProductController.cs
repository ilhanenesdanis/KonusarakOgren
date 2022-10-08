using DTO;
using Microsoft.AspNetCore.Mvc;
using WebUI.APIHandler;
using WebUI.Models;

namespace WebUI.Controllers
{
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
            addProduct.CompanyId = 1;
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
    }
}
