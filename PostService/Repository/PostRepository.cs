using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(PostContext context) : base(context) { }

    

        public IEnumerable<Post> GetAllUserPosts(long id)
        {
            return PostContext.Posts.Where(x => !x.Deleted && x.UserID == id).ToList();
        }

        public IEnumerable<Post> GetAllUsersPosts(List<long> ids)
        {
            return PostContext.Posts.Where(x => !x.Deleted && ids.Contains(x.UserID)).ToList();
        }
    }
}
