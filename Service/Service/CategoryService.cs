using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
    }
}
