using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository(PostContext context) : base(context) { }
    }
}
