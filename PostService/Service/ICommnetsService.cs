using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public interface ICommentsService
    {
        IEnumerable<Comments> GetAllPostComments(long id);

        IEnumerable<Comments> GetAllUserComments(long id);
    }
}
