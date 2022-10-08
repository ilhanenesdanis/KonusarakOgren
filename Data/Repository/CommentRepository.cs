using Core.Entity;
using Core.IRepository;

namespace Data.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(Context context) : base(context)
        {
        }
    }
}
