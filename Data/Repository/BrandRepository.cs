using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(Context context) : base(context)
        {
        }
    }
}
