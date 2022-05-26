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
        public IEnumerable<Job> GetAllById(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new JobContext());
                return unitOfWork.Jobs.GetAllById(id);
            }
            catch(Exception e)
            {

                return new List<Job>();
            }
        }

        public IEnumerable<Job> GetAllByPosition(string s)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new JobContext());

                return unitOfWork.Jobs.GetAllByPosition(s);
            }
            catch (Exception e)
            {
                return new List<Job>();
            }
        }
    }
}
