using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllUserPosts(long id);

        IEnumerable<Post> GetAllUsersPosts(List<long> ids);
        bool Update(long id, Post ent);

    }
}
