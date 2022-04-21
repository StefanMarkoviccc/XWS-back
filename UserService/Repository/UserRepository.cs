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

        public IEnumerable<User> GetPublicUsers()
        {
            return UserContext.Users.Where(x => x.IsPublic).ToList();
        }

        public User GetUserWithEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUserWithRegistationToken(string token)
        {
            throw new NotImplementedException();
        }

        public User GetUserWithRegistrationToken(string token)
        {
            throw new NotImplementedException();
        }

        public User GetUserWithResetToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
