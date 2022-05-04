using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public class ReactionRepository : BaseRepository<Reaction>, IReactionRepository
    {
        public ReactionRepository(PostContext context) : base(context) { }



        public IEnumerable<Reaction> GetAllPostReactions(long id)
        {
            return PostContext.Reactions.Where(x => !x.Deleted && x.PostId == id).ToList();
        }
    }
}
