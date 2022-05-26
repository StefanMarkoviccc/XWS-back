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

        [HttpGet("/{id}")]
        public virtual IActionResult GetAllById(int id)
        {
            return Ok(jobService.GetAllById(id));
        }

        [HttpGet("position/{s}")]
        public virtual IActionResult GetAllByPosition(string s)
        {
            return Ok(jobService.GetAllByPosition(s));
        }
    }
}
