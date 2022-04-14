using JobService.Model;
using JobService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Service
{
    public class JobService : BaseService<Job>,IJobService
    {
        public IEnumerable<Job> GetAllByPosition(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new JobContext());
                return unitOfWork.Jobs.GetAllByPosition(id);
            }
            catch(Exception e)
            {

                return new List<Job>();
            }
        }
    }
}
