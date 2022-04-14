using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model
{
    public class Post : Entity
    {
        public String content { get; set; }
        public String image { get; set; }

    }
}
