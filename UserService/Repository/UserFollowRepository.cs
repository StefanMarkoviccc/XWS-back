using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Repository
{
    public class UserFollowRepository : BaseRepository<UserFollow>, IUserFollowRepository
    {
        public UserFollowRepository(UserContext context) : base(context) { }
    }
}
