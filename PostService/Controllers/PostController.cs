using Microsoft.AspNetCore.Mvc;
using PostService.Configuration;
using PostService.Model;
using PostService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class PostController : BaseController<Post>
        {
            private IPostService postService;

            public PostController(ProjectConfiguration projectConfiguration,
                IPostService postService) : base(projectConfiguration, null)
            {
                this.postService = postService;
            }

            [HttpGet("userPosts/{id}")]
            public virtual IActionResult GetAllUserPosts(int id)
            {
                return Ok(postService.GetAllUserPosts(id));
            }

        }
    }

