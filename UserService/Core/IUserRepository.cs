using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Core
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserWithEmail(string email);
        User GetUserWithRegistationToken(string token);
        User GetUserWithResetToken(string token);
        User GetUserWithEmailAndPassword(string email, string password);
        User GetUserWithRegistrationToken(string token);
    }
}
