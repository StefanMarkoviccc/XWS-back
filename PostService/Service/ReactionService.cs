using Microsoft.Extensions.Logging;
using PostService.Model;
using PostService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public class ReactionService : BaseService<Reaction>, IReactionService
    {
        public ReactionService(ILogger<ReactionService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Reaction> GetAllPostReactions(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new PostContext());

                return unitOfWork.Reactions.GetAllPostReactions(id);
            }
            catch (Exception e)
            {
                return new List<Reaction>();
            }
        }

    }
}
