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
    public class CommentsController : BaseController<Comments>
    {
        private ICommentsService commentsService;

        public CommentsController(ProjectConfiguration projectConfiguration,
            ICommentsService commentsService) : base(projectConfiguration, null)
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
