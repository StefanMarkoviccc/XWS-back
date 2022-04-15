﻿using PostService.Model;
using PostService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Service
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService() { }
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

    }
}
