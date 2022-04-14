using JobService.Configuration;
using JobService.Model;
using JobService.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Controllers
{
    public class JobController : BaseController<Job>
    {
        private IJobService jobService;

        public JobController(ProjectConfiguration projectConfiguration, IUserService userService,
            IJobService jobService) : base(projectConfiguration, userService)
        {
            this.jobService = jobService;
        }

        [HttpGet("position/{id}")]
        public virtual IActionResult GetAllByPosition(int id)
        {
            return Ok(jobService.GetAllByPosition(id));
        }
    }
}
