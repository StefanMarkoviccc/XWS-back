using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Model;
using UserService.Service;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserWhoFollowController : BaseController<User>
    {
        private IUserWhoFollowService userWhoFollowService;

        public UserWhoFollowController(ProjectConfiguration projectConfiguration,
            IUserService userService, IUserWhoFollowService userWhoFollowService) : base(projectConfiguration, userService)
        {
            this.userWhoFollowService = userWhoFollowService;
        }
    }
}
