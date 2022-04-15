using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public class ReactionRepository : BaseRepository<Post>, IReactionRepository
    {
        public ReactionRepository(PostContext context) : base(context) { }



        public IEnumerable<Post> GetAllPostReactions(long id)
        {
            return PostContext.Posts.Where(x => !x.Deleted && x.PostId == id).ToList();
        }
    }
}
