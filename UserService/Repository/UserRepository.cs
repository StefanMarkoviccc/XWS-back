using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Core;
using UserService.Model;

namespace UserService.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context) { }

        public IEnumerable<User> GetPublicUsers(string term)
        {
            if (term is null || term == string.Empty) 
            {
                return UserContext.Users.Where(x => x.IsPublic).ToList();
            }

            return UserContext.Users.Where(x => x.IsPublic && (x.FirstName.Contains(term) || x.LastName.Contains(term))).ToList();
        }

        public User GetUserWithEmail(string email)
        {
            return UserContext.Users.Where(x => x.Email == email).SingleOrDefault();
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            return UserContext.Users.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
        }

        public User GetUserWithRegistationToken(string token)
        {
            return UserContext.Users.Where(x => x.RegistrationToken == token).SingleOrDefault();
        }

        public User GetUserWithRegistrationToken(string token)
        {
            return UserContext.Users.Where(x => x.RegistrationToken == token).SingleOrDefault();
        }

        public User GetUserWithResetToken(string token)
        {
            return UserContext.Users.Where(x => x.ResetPasswordToken == token).SingleOrDefault();
        }

        public User Search(string token)
        {
            return UserContext.Users.Where(x => x.LastName.Contains(token) || x.FirstName.Contains(token)).SingleOrDefault();
        }
    }
}
