using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Repository
{
    public class UserFollowRepository : BaseRepository<UserFollow>, IUserFollowRepository
    {
        public UserFollowRepository(UserContext context) : base(context) {
        
        
        }
       
        public IEnumerable<UserFollow> GetAllUserFollowers(long id)
        {
            return UserContext.UserFollows.Where(x => !x.Deleted && x.User.Id == id).ToList();
        }
    }
}
