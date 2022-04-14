using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        public bool Activate(string token)
        {
            throw new NotImplementedException();
        }

        public User ChangePasswordWithToken(UserService userData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserWithEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUserWithRegistrationToken(string token)
        {
            throw new NotImplementedException();
        }

        public bool PasswordReset(string token, string password)
        {
            throw new NotImplementedException();
        }

        public bool RequestPasswordReset(string email)
        {
            throw new NotImplementedException();
        }
    }
}
