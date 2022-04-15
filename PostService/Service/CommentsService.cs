using PostService.Model;
using PostService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public class CommentsService : BaseService<Post>, ICommentsService
    {
        public CommentsService() { }
        public IEnumerable<Post> GetAllPostComments(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new PostContext());

                return unitOfWork.Comments.GetAllPostComments(id);
            }
            catch (Exception e)
            {
                return new List<Post>();
            }
        }

        public IEnumerable<Post> GetAllUserComments(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new PostContext());

                return unitOfWork.Comments.GetAllUserComments(id);
            }
            catch (Exception e)
            {
                return new List<Post>();
            }
        }

    }
}
