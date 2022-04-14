using JobService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Service
{
    public interface IJobService
    {
        IEnumerable<Job> GetAllByPosition(long id);
        
    }
}
