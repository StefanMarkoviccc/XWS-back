using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllUserPosts(long id);
     
    }
}
