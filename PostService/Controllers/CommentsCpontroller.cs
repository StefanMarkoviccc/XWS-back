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
    [Route("[controller]")]
    public class CommentsController : BaseController<Post>
    {
        private ICommentsService commentsService;

        public CommentsController(ProjectConfiguration projectConfiguration, IUserService userService,
            ICommentsService commentsService) : base(projectConfiguration, userService)
        {
            this.commentsService = commentsService;
        }

        [HttpGet("postComments/{id}")]
        public virtual IActionResult GetAllPostComments(int id)
        {
            return Ok(commentsService.GetAllPostComments(id));
        }

        [HttpGet("userComments/{id}")]
        public virtual IActionResult GetAllUserComments(int id)
        {
            return Ok(commentsService.GetAllUserComments(id));
        }

    }
}
