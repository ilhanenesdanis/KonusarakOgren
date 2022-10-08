using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(Context context) : base(context)
        {
        }
    }
}
