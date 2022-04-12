using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Model
{
    public class CreateJob : Entity
    {
       public String JobDescription { get; set; }
       public String JobPosition { get; set; }
       public String ActivityLog { get; set; }
       public String JobConditions { get; set; }
    }
}
