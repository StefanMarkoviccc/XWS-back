using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model
{
    public class PostSettings : Entity
    {
        public long UserId { get; set; }

        public bool IsActive { get; set; }
    }
}
