﻿using JobService.Configuration;
using JobService.Model;
using JobService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IntegrationController : BaseController<Job>
    {
        private IJobService jobService;
        private IApiKeyService apiKeyService;
        public IntegrationController(ProjectConfiguration config, IJobService jobService, IApiKeyService apiKeyService, IUserService userService) : base(config,userService)
        {
            this.jobService = jobService;
            this.apiKeyService = apiKeyService;
        }

        [Route("saveJob")]
        [HttpPost]
        public IActionResult Create(Job job)
        {
            StringValues apiKey = string.Empty;
            Request.Headers.TryGetValue("X-API-KEY", out apiKey);

            string key = apiKey.First();
            ApiKey api = apiKeyService.CheckIfApiKeyExists(key);
            if (api == null)
            {
                return BadRequest("Api Key invalid");
            }

            return Ok(jobService.AddJob(job, api.UserId));
        }

    }
}
