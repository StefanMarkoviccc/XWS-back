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

        public IEnumerable<Job> GetAllByPosition(long id)
        {
            throw new NotImplementedException();
        }
    }
}
