using JobService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Repository
{
    public class ApiKeyRepository : BaseRepository<ApiKey>,IApiKeyRepository
    {
        public ApiKeyRepository(JobContext context) : base(context) { }

        public IEnumerable<ApiKey> GetAllById(long id)
        {
            throw new NotImplementedException();
        }

        public ApiKey CheckIfApiKeyExists(string api)
        {
            return JobContext.ApiKeys.Where(x => x.ApiKeyString.Contains(api)).FirstOrDefault();
        }
    }
}
