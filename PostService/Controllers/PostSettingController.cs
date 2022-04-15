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
    public class PostSettingController : BaseController<PostSettings>
    {
        private IPostSettingsService postSettingsService;
        public PostSettingController(ProjectConfiguration projectConfiguration, IUserService userService, IPostSettingsService postSettingsService) : base(projectConfiguration, userService)
        {
            this.postSettingsService = postSettingsService;
        }
    }
}
