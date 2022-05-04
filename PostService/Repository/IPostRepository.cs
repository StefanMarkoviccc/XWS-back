using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        IEnumerable<Post> GetAllUserPosts(long id);
        IEnumerable<Post> GetAllUsersPosts(List<long> ids);
    }
}
