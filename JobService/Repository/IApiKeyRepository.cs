using JobService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Repository
{
    public interface IApiKeyRepository
    {
        IEnumerable<ApiKey> GetAllById(long id);

        void Add(ApiKey apiKey);

    }
}
