using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.DTO;
using UserService.Model;
using UserService.Service;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserWhoFollowController : BaseController<User>
    {
        private IUserWhoFollowService userWhoFollowService;

        public UserWhoFollowController(ProjectConfiguration projectConfiguration,
            IUserService userService, IUserWhoFollowService userWhoFollowService) : base(projectConfiguration, userService)
        {
            this.userWhoFollowService = userWhoFollowService;
        }

        [HttpGet("/{id}")]
        public virtual IActionResult GetAllUserFollows(int id)
        {
            return Ok(userWhoFollowService.GetAllUserFollowers(id));
        }


        [Route("add")]
        [HttpPost]
        public IActionResult Add(UserFollowDTO dto) 
        {
            return Ok(userWhoFollowService.Add(dto));
        }

        [Route("approve/{id}")]
        [HttpPut]
        public IActionResult Approve(long id)
        {
            return Ok(userWhoFollowService.Approve(id));
        }

        [Route("reject/{id}")]
        [HttpPut]
        public IActionResult Reject(long id)
        {
            return Ok(userWhoFollowService.Reject(id));
        }
    }
}
