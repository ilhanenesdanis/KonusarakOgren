using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class ProductCategoryService : Service<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(IUnitOfWork unitOfWork, IRepository<ProductCategory> repository) : base(unitOfWork, repository)
        {
        }
    }
}
