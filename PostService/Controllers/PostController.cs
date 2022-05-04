using Microsoft.AspNetCore.Mvc;
using PostService.Configuration;
using PostService.DTO;
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

        [HttpPost("userPublicPosts")]
        public virtual IActionResult GetPublicUserPosts(PublicUserDTO dto)
            {
                return Ok(postService.GetAllUsersPosts(dto.UsersIds));
            }

        [HttpPut("{id}")]
        public override IActionResult Update(int id, Post entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            bool response = postService.Update(id, entity);
            
            return Ok(response);
        }

    }
    }

