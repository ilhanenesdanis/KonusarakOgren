using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class ProductFeaturesService : Service<ProductFeatures>, IProductFeaturesService
    {
        public ProductFeaturesService(IUnitOfWork unitOfWork, IRepository<ProductFeatures> repository) : base(unitOfWork, repository)
        {
        }
    }
}
