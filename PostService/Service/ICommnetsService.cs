using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public interface ICommentsService
    {
        IEnumerable<Post> GetAllPostComments(long id);

        IEnumerable<Post> GetAllUserComments(long id);
    }
}
