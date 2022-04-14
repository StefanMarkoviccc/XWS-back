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
    public class MessageController : BaseController<Message>
    {
        private IMessageService messageService;

        public MessageController(ProjectConfiguration projectConfiguration, IUserService userService,
            IMessageService messageService) : base(projectConfiguration, userService)
        {
            this.messageService = messageService;
        }

        [HttpGet("sender/{id}")]
        public virtual IActionResult GetAllBySender(int id)
        {
            return Ok(messageService.GetAllBySender(id));
        }

        [HttpGet("recipient/{id}")]
        public virtual IActionResult GetAllByRecipient(int id)
        {
            return Ok(messageService.GetAllByRecipient(id));
        }
    }
}
