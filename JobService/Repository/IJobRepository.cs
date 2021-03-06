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

        IEnumerable<Job> GetAll();

        IEnumerable<Job> GetAll(string term);

    }
}
