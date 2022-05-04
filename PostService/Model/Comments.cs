using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model
{
    public class Comments : Entity
    {
        public long PostId { get; set; }

        public long UserID { get; set; }

        public string Content { get; set; }
    }
}
