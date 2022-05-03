using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;
using UserService.Repository;

namespace UserService.Service
{
    public class UserWhoFollowService : BaseService<User>, IUserWhoFollowService
    {
        public UserWhoFollowService() { }

    }
}
