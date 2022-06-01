using JobService.Model;
using JobService.Repository;
using JobService.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Service
{
    public class ApiKeyService : BaseService<ApiKey>,IApiKeyService
    {
        public override ApiKey Add(ApiKey entity)
        {
            if(entity == null)
            {
                return null;
            }

            ApiKey apiKey = new ApiKey();

            try
            {
                using UnitOfWork unitOfWork = new(new JobContext());

                apiKey.ApiKeyString = RandomStringHelper.RandomString(5);
                apiKey.UserId = entity.UserId;
                unitOfWork.ApiKeys.Add(apiKey);
                _ = unitOfWork.Complete();
            }

            catch(Exception e)
            {
                _logger.LogError($"Error in JobService in Add Method {e.Message} {e.StackTrace}");
                return null;
            }

            return apiKey;
        }




        public IEnumerable<ApiKey> GetAllById(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new JobContext());
                return unitOfWork.ApiKeys.GetAllById(id);
            }
            catch (Exception e)
            {

                return new List<ApiKey>();
            }
        }
    }
}
