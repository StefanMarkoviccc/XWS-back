using Microsoft.Extensions.Logging;
using PostService.Model;
using PostService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public class CommentsService : BaseService<Comments>, ICommentsService
    {
        public CommentsService(ILogger<CommentsService> logger) 
        {
            _logger = logger;
        }

        public IEnumerable<Comments> GetAllPostComments(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new PostContext());

                return unitOfWork.Comments.GetAllPostComments(id);
            }
            catch (Exception e)
            {
                return new List<Comments>();
            }
        }

        public IEnumerable<Comments> GetAllUserComments(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new PostContext());

                return unitOfWork.Comments.GetAllUserComments(id);
            }
            catch (Exception e)
            {
                return new List<Comments>();
            }
        }

    }
}
