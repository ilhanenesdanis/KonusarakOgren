using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(Context context) : base(context)
        {
        }
    }
}
