using Core.Entity;
using Core.IService;
using DTO;

namespace Service.IService
{
    public interface IProductService:IService<Product>
    {
        int AddNewProduct(AddProductDto addProduct);
        List<ProductDto> GetAllProducts();
        List<ProductDto> GetAllProducts(int id);
        List<ProductFeaturesDto> GetProductFeatures(int productId);
    }
}
