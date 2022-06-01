using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Repository
{
    public interface IUserFollowRepository : IBaseRepository<UserFollow>
    {
        IEnumerable<UserFollow> GetAllUserFollowers(long id);

        IEnumerable<UserFollow> GetAllUserApproveFollowers(long id);


    }
}
