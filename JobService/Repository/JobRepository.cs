using JobService.Model;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Repository
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(JobContext context ) : base(context) { }

        public IEnumerable<Job> GetAllById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> GetAllByPosition(string s)
        {
            return JobContext.Jobs.Where(x => !x.Deleted && x.JobPosition.Contains(s)).ToList();
        }

        public IEnumerable<Job> GetAll(string term)
        {
            if (term is null || term == string.Empty)
            {
                return JobContext.Jobs.Where(x => !x.Deleted).ToList();
            }

            return JobContext.Jobs.Where(x => !x.Deleted && (x.JobConditions.Contains(term) || x.JobDescription.Contains(term) || x.JobPosition.Contains(term))).ToList();
        }

    }
}
