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
    public class ReactionController : BaseController<Post>
    {
        private IReactionService reactionService;

        public ReactionController(ProjectConfiguration projectConfiguration, IUserService userService,
            IReactionService reactionService) : base(projectConfiguration, userService)
        {
            this.reactionService = reactionService;
        }

        [HttpGet("postReaction/{id}")]
        public virtual IActionResult GetAllPostReactions(int id)
        {
            return Ok(reactionService.GetAllPostReactions(id));
        }

    }
}
