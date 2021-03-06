using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.DTO;
using UserService.Model;

namespace UserService.Service
{
    public interface IUserWhoFollowService
    {
        UserFollow Add(UserFollowDTO dto);
        UserFollow Approve(long id);

        IEnumerable<UserFollow> GetAllUserFollowers(long id);

        IEnumerable<UserFollow> GetAllUserApproveFollowers(long id);


        UserFollow Reject(long id);
    }
}
