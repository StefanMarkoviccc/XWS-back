using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class UserFollow : Entity
    {
        public User User { get; set; }
        public User UserWhoFollow { get; set; }
    }
}
