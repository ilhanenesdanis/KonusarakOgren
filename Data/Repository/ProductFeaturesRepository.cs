using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class ProductFeaturesRepository : Repository<ProductFeatures>, IProductFeaturesRepository
    {
        public ProductFeaturesRepository(Context context) : base(context)
        {
        }
    }
}
