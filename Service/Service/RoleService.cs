using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IRepository<Role> repository) : base(unitOfWork, repository)
        {
        }
    }
}
