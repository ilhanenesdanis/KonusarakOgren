using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(Context context) : base(context)
        {
        }
    }
}
