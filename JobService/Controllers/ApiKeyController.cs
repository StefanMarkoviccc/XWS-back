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
    [ApiController]
    [Route("api/[controller]")]
    public class ApiKeyController : BaseController<ApiKey>
    {
        private IApiKeyService apiKeyService;

        public ApiKeyController(ProjectConfiguration projectConfiguration, IApiKeyService apiKeyService) : base(projectConfiguration, null)
        {
            this.apiKeyService = apiKeyService;
        }

        [Route("createApiKey")]
        [HttpPost]
        public IActionResult Create(ApiKey apiKey)
        {
            return Ok(apiKeyService.Add(apiKey));
        }
    }
}
