using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model
{
    public class Post : Entity
    {
        public String Content { get; set; }
        public String Image { get; set; }

        public long PostId { get; set; }

        public long UserID { get; set; }

        public Reaction Reaction { get; set; }


    }
}
