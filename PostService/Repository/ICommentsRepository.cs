using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public interface ICommentsRepository
    {
        IEnumerable<Post> GetAllPostComments(long id);

        IEnumerable<Post> GetAllUserComments(long id);
    }
}
