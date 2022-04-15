using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public class CommentsRepository : BaseRepository<Post>, ICommentsRepository
    {
        public CommentsRepository(PostContext context) : base(context) { }



        public IEnumerable<Post> GetAllPostComments(long id)
        {
            return PostContext.Posts.Where(x => !x.Deleted && x.PostId == id).ToList();
        }

        public IEnumerable<Post> GetAllUserComments(long id)
        {
            return PostContext.Posts.Where(x => !x.Deleted && x.UserID == id).ToList();
        }
    }
}
