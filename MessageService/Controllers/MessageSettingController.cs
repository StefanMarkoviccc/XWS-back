using MessageService.Configuration;
using MessageService.Model;
using MessageService.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageSettingController : BaseController<MessageSettings>
    {
        private IMessageSettingsService messageSettingsService;
        public MessageSettingController(ProjectConfiguration projectConfiguration, IUserService userService, IMessageSettingsService messageSettingsService) : base(projectConfiguration, userService) {
            this.messageSettingsService = messageSettingsService;
        }
    }
}
