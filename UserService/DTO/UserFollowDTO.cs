using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.DTO
{
    public class UserFollowDTO
    {
        public long UserID { get; set; }
        public long UserWhoFollowID { get; set; }
    }
}
