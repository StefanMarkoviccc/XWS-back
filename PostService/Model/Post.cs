using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model
{
    public class Post : Entity
    {
        public string Content { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public long PostId { get; set; }
        public long UserID { get; set; }

    }
}
