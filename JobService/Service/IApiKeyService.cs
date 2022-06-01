using JobService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface IApiKeyService
    {
        IEnumerable<ApiKey> GetAllById(long id);
        ApiKey Add(ApiKey entity);

    }
}
