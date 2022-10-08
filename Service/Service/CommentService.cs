using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IService;

namespace Service.Service
{
    public class CommentService : Service<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IRepository<Comment> repository) : base(unitOfWork, repository)
        {
        }
    }
}
