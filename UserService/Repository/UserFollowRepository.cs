using Microsoft.EntityFrameworkCore;
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
            return UserContext.UserFollows.Include(x => x.UserWhoFollow).Include(x => x.User).Where(x => !x.Deleted && x.User.Id == id).ToList();
        }
        public IEnumerable<UserFollow> GetAllUserApproveFollowers(long id)
        {
            return UserContext.UserFollows.Include(x => x.UserWhoFollow).Include(x => x.User).Where(x => !x.Deleted && x.UserWhoFollow.Id == id && x.Status == UserFollowStatus.APPROVED).ToList();
        }

    }
}
