using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class DiscountService : Service<Discount>, IDiscountService
    {
        public DiscountService(IUnitOfWork unitOfWork, IRepository<Discount> repository) : base(unitOfWork, repository)
        {
        }
    }
}
