using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(Context context) : base(context)
        {
        }
    }
}
