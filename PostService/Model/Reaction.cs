using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model
{
    public class Reaction : Entity
    {
        public ReactionType ReactionType { get; set; }

        public long PostId { get; set; }

        public long UserId { get; set; }
    }
}
