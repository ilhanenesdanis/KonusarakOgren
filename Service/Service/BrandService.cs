using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class BrandService : Service<Brand>, IBrandService
    {
        public BrandService(IUnitOfWork unitOfWork, IRepository<Brand> repository) : base(unitOfWork, repository)
        {
        }
    }
}
