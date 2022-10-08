using AutoMapper;
using Core.Entity;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductFeaturesService _productFeaturesService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper, IProductFeaturesService productFeaturesService)
        {
            _productService = productService;
            _mapper = mapper;
            _productFeaturesService = productFeaturesService;
        }
        #region Ürün için ekleme-Toplu Listeleme-Firmaya göre listeleme Fonksiyonları
        [HttpPost]
        public IActionResult AddProduct(AddProductDto addProduct)
        {
            _productService.AddNewProduct(addProduct);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var result = _productService.GetAllProducts();
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, result));
        }
        [HttpGet("{companyId}")]
        public IActionResult GetAllCompanyProducts(int companyId)
        {
            var result = _productService.GetAllProducts(companyId);
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, result));
        }
        #endregion
        [HttpGet("{productId}")]
        public IActionResult GetProductFeatures(int productId)
        {
            var result=_productService.GetProductFeatures(productId);
            return CreateActionResult(CustomResponseDto<List<ProductFeaturesDto>>.Success(200,result));
        }
        [HttpPost]
        public IActionResult AddProductFeature(AddProductFeatureDto addProductFeature)
        {
            var mapping = _mapper.Map<ProductFeatures>(addProductFeature);
            _productFeaturesService.Add(mapping);
            return CreateActionResult(CustomResponseDto<ProductFeaturesDto>.Success(200));
        }


    }
}
