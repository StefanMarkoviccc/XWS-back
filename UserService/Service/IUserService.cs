using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Service
{
    public interface IUserService
    {
        User Add(User entity);
        User GetUserWithEmailAndPassword(string email, string password);
        User GetUserWithEmail(string email);
        User Get(long id);
        User CreateUser(User user);
        User GetUserWithRegistrationToken(string token);
        User ChangePasswordWithToken(User userData);
        bool RequestPasswordReset(string email);
        bool PasswordReset(string token, string password);
        bool Activate(string token);
        IEnumerable<User> GetAll();
    }
}
