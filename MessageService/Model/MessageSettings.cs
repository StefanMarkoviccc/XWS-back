using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Model
{
    public class MessageSettings : Entity
    {
        public long UserId { get; set; }

        public bool IsActive { get; set; }


    }
}
