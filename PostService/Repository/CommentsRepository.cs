using PostService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public class CommentsRepository : BaseRepository<Comments>, ICommentsRepository
    {
        public CommentsRepository(PostContext context) : base(context) { }



        public IEnumerable<Comments> GetAllPostComments(long id)
        {
            return PostContext.Comments.Where(x => !x.Deleted && x.PostId == id).ToList();
        }

        public IEnumerable<Comments> GetAllUserComments(long id)
        {
            return PostContext.Comments.Where(x => !x.Deleted && x.UserID == id).ToList();
        }
    }
}
