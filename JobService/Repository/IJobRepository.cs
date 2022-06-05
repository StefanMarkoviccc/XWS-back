using JobService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Repository
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        IEnumerable<Job> GetAllById(long id);
        IEnumerable<Job> GetAllByPosition(string s);
<<<<<<< HEAD
        IEnumerable<Job> GetAll();
=======

        IEnumerable<Job> GetAll(string term);

>>>>>>> 67d13e9fd69e3efa3715b95deeed0e31958b0dbd
    }
}
