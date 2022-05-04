using Microsoft.Extensions.Logging;
using PostService.Model;
using PostService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(ILogger<PostService> logger) 
        {
            _logger = logger;
        }

        public IEnumerable<Post> GetAllUserPosts(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new PostContext());

                return unitOfWork.Posts.GetAllUserPosts(id);
            }
            catch (Exception e)
            {
                return new List<Post>();
            }
        }

        public IEnumerable<Post> GetAllUsersPosts(List<long> ids)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new PostContext());

                return unitOfWork.Posts.GetAllUsersPosts(ids);
            }
            catch (Exception e)
            {
                return new List<Post>();
            }
        }

        public override bool Update(long id, Post post)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new PostContext());

                Post postDB = Get(id);

                postDB.Content = post.Content;
                postDB.Image = post.Image;

                unitOfWork.Posts.Update(postDB);
                _ = unitOfWork.Complete();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

