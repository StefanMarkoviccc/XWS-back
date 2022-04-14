using JobService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Repository
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetAllByPosition(long id);
    }
}
