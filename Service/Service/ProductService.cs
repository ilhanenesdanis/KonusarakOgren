using AutoMapper;
using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using DTO;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCategory> _productCategory;
        private readonly IRepository<ProductFeatures> _productFeature;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository, IRepository<ProductCategory> productCategory, IRepository<ProductFeatures> productFeature, IMapper mapper) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = repository;
            _productCategory = productCategory;
            _productFeature = productFeature;
            _mapper = mapper;
        }

        public int AddNewProduct(AddProductDto addProduct)
        {
            string barcodeNo = Guid.NewGuid().ToString().Substring(0, 10);
            Product product = new Product()
            {
                BarcodeNo = barcodeNo,
                BrandId = addProduct.BrandId,
                Name = addProduct.Name,
                SalePrice = addProduct.SalePrice,
                Stock = addProduct.Stock,
                CompanyId=addProduct.CompanyId
            };
            _productRepository.Add(product);
            var saveProduct = _unitOfWork.saveChanges();
            if (saveProduct > 0)
            {
                foreach (var item in addProduct.CategoryId)
                {
                    ProductCategory category = new ProductCategory()
                    {
                        CategoryId = item,
                        ProductId = product.Id,
                    };
                    _productCategory.Add(category);
                    _unitOfWork.saveChanges();
                }
                ProductFeatures features = new ProductFeatures()
                {
                    Color = addProduct.Color,
                    Height = addProduct.Height,
                    ProductId = product.Id,
                    Width = addProduct.Width,
                    ProductDescription = addProduct.ProductDescription,
                    Size = addProduct.Size
                };
                _productFeature.Add(features);
                _unitOfWork.saveChanges();
                return 1;
            }
            return 0;
        }

        public List<ProductDto> GetAllProducts()
        {
            var list = _productRepository.GetBy(x => x.Status == true).Include(x => x.Brand)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .Include(x => x.ProductFeatures)
                .ThenInclude(x => x.Discounts).AsNoTracking().ToList();
            var mapping = _mapper.Map<List<ProductDto>>(list);
            return mapping;
        }

        public List<ProductDto> GetAllProducts(int id)
        {
            var list = _productRepository.GetBy(x => x.Status == true && x.CompanyId == id).Include(x => x.Brand)
                 .Include(x => x.ProductCategories)
                 .ThenInclude(x => x.Category)
                 .Include(x => x.ProductFeatures)
                 .ThenInclude(x => x.Discounts).AsNoTracking().ToList();
            var mapping = _mapper.Map<List<ProductDto>>(list);
            return mapping;
        }

        public List<ProductFeaturesDto> GetProductFeatures(int productId)
        {
            var list = _productFeature.GetBy(x => x.ProductId == productId).Include(x => x.Product).ToList();
            var mapping = _mapper.Map<List<ProductFeaturesDto>>(list);
            return mapping;
        }
    }
}
