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
    public class ReactionController : BaseController<Reaction>
    {
        private IReactionService reactionService;

        public ReactionController(ProjectConfiguration projectConfiguration,
            IReactionService reactionService) : base(projectConfiguration, null)
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
