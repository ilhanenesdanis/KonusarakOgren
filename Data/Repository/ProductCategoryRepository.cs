using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(Context context) : base(context)
        {
        }
    }
}
