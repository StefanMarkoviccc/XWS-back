using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Model
{
    public class ApiKey : Entity
    {
        public long UserId { get; set; }

        public string ApiKeyString { get; set; } 
    }
}
