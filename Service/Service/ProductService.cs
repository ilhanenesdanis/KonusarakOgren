using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }
    }
}
