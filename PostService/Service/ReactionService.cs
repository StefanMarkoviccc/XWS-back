using PostService.Model;
using PostService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public class ReactionService : BaseService<Post>, IReactionService
    {
        public ReactionService() { }
        public IEnumerable<Post> GetAllPostReactions(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new PostContext());

                return unitOfWork.Reactions.GetAllPostReactions(id);
            }
            catch (Exception e)
            {
                return new List<Post>();
            }
        }

    }
}
