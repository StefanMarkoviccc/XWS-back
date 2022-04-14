using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Model
{
    public class Job : Entity
    {
       public string JobDescription { get; set; }
       public string JobPosition { get; set; }
       public string ActivityLog { get; set; }
       public string JobConditions { get; set; }
    }
}
