using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Model;
using UserService.Repository;
using UserService.Util;

namespace UserService.Service
{
    public class UserService : BaseService<User>, IUserService
    {

        private readonly IEmailService _emailService;
        private readonly ILogger _logger;
        private readonly ProjectConfiguration _configuration;

        public UserService(ProjectConfiguration configuration, ILogger<UserService> logger, IEmailService emailService)
        {
            _emailService = emailService;
            _logger = logger;
            _configuration = configuration;
        }

        public override User Add(User entity)
        {
            if(entity == null)
            {
                return null;
            }

            try
            {
                using UnitOfWork unitOfWork = new(new UserContext());
                entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
                entity.Enabled = true;
                entity.UserType = UserType.Admin;
                entity.RegistrationToken = RandomStringHelper.RandomString(20);
                unitOfWork.Users.Add(entity);
                _ = unitOfWork.Complete();

                _ = _emailService.Send(entity.Email, subject: "Activate account", body: $"{_configuration.FrontendURL}/user/activate?token={entity.RegistrationToken}");

            }

            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in AddUserMethod {e.Message} {e.StackTrace}");
                return null;
            }
            return entity;
        }

        public User GetUSerWithEmailAndPassword(string email, string password)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new UserContext());
                User user = unitOfWork.Users.GetUserWithEmail(email);

                if(!BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return null;
                }

                return user;

            }

            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in GetUserWithEmailAndPasswordMethod {e.Message} {e.StackTrace}");
                return null;
            }

        }

        public IEnumerable<User> Search(string id)
        {

            try
            {
                using UnitOfWork unitOfWord = new(new UserContext());
                return unitOfWord.Users.Search();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in Search {e.Message} {e.StackTrace}");
                return new List<User>();
            }
            //try
            //{
            //    using UnitOfWork unitOfWork = new(new UserContext());



            //    User user = unitOfWork.Users.GetUserWithEmail(id);  

            //    return user;

            //}

            //catch (Exception e)
            //{
            //    _logger.LogError($"Error is UserService in GetUserWithEmailAndPasswordMethod {e.Message} {e.StackTrace}");
            //    return null;
            //}

        }

        public User GetUserWithEmail(string email)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new UserContext());
                return unitOfWork.Users.GetUserWithEmail(email);

            }

            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in GetUserWithEmailMethod {e.Message} {e.StackTrace}");
                return null;
            }

        }

        public User GetUserWithRegistrationToken(string token)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new UserContext());
                return unitOfWork.Users.GetUserWithRegistationToken(token);

            }

            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in GetUserWithRegistrationTokenMethod {e.Message} {e.StackTrace}");
                return null;
            }

        }

        public User ChangePasswordWithToken(User userData)
        {

            if(userData == null)
            {
                return null;
            }

            try
            {
                using UnitOfWork unitOfWork = new(new UserContext());
                User userFound = unitOfWork.Users.GetUserWithRegistationToken(userData.RegistrationToken);

                userFound.Password = BCrypt.Net.BCrypt.HashPassword(userData.Password);
                userFound.DateUpdated = DateTime.Now;

                unitOfWork.Users.Update(userFound);
                _ = unitOfWork.Complete();
            }

            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in ChangePasswordWithTokenMethod {e.Message} {e.StackTrace}");
                return null;
            }
            return userData;

        }

        public bool Activate(string token)
        {
            try
            {
                using UnitOfWork unitOfWord = new(new UserContext());
                User user = unitOfWord.Users.GetUserWithRegistationToken(token);

                if (user == null)
                {
                    return false;
                }

                unitOfWord.Users.Update(user);

                user.ResetPasswordToken = null;
                user.Enabled = true;

                _ = unitOfWord.Complete();
              
            }
            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in Activate {e.Message} {e.StackTrace}");
                return false;
            }
            return true;
        }

        public IEnumerable<User> GetPublicUsers(string term)
        {
            try
            {
                using UnitOfWork unitOfWord = new(new UserContext());
                return unitOfWord.Users.GetPublicUsers(term);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in PublicUsersMethod {e.Message} {e.StackTrace}");
                return new List<User>();
            }
        }

        public User CreateUser(User userData)
        {
            if(userData == null)
            {
                return null;
            }

            try
            {
                using UnitOfWork unitOfWord = new(new UserContext());
                userData.UserType = UserType.Admin;
                userData.Password = BCrypt.Net.BCrypt.HashPassword(userData.Password);
                userData.Enabled = true;
                unitOfWord.Users.Add(userData);
                _ = unitOfWord.Complete();

            }
            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in CreateUserMethod {e.Message} {e.StackTrace}");
                return null;
            }
            return userData;
        }

        public User ChangePasswordWithToken(UserService userData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                using UnitOfWork unitOfWord = new(new UserContext());
                return unitOfWord.Users.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in CreateUserMethod {e.Message} {e.StackTrace}");
                return new List<User>();
            }
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            try
            {
                using UnitOfWork unitOfWord = new(new UserContext());
                return unitOfWord.Users.GetUserWithEmailAndPassword(email, password);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in CreateUserMethod {e.Message} {e.StackTrace}");
                return null;
            }
        }

        public User GetUserWithRegistationToken(string token)
        {
            try
            {
                using UnitOfWork unitOfWord = new(new UserContext());
                return unitOfWord.Users.GetUserWithRegistationToken(token);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in CreateUserMethod {e.Message} {e.StackTrace}");
                return null;
            }
        }

        public bool PasswordReset(string token, string password)
        {
            try
            {
                using UnitOfWork unitOfWord = new(new UserContext());
                User user = unitOfWord.Users.GetUserWithResetToken(token);

                if (user == null)
                {
                    return false;
                }

                unitOfWord.Users.Update(user);

                user.ResetPasswordToken = null ;
                user.Enabled = false;
                user.Password = BCrypt.Net.BCrypt.HashPassword(password);

                _ = unitOfWord.Complete();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in PasswordResetMethod {e.Message} {e.StackTrace}");
                return false;
            }
            return true;
        }

        public bool RequestPasswordReset(string email)
        {
            try
            {
                using UnitOfWork unitOfWord = new(new UserContext());
                User user = unitOfWord.Users.GetUserWithEmail(email);

                if (user == null || user.ResetPasswordToken != null)
                {
                    return false;
                }

                unitOfWord.Users.Update(user);

                user.ResetPasswordToken = RandomStringHelper.RandomString(20);
                user.Enabled = false;

                _ = unitOfWord.Complete();
                _ = _emailService.Send(email, subject: "Password rest", body: $"{_configuration.FrontendURL}/reset-password?token={user.ResetPasswordToken}");

            }
            catch (Exception e)
            {
                _logger.LogError($"Error is UserService in RequestPasswordResetMethod {e.Message} {e.StackTrace}");
                return false;
            }
            return true;
        }

        public override bool Update(long id, User user)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new UserContext());

                User userDB = Get(id);

                userDB.Email = user.Email;
                userDB.FirstName = user.FirstName;
                userDB.LastName = user.LastName;
                userDB.Phone = user.Phone;
                userDB.Gender = user.Gender;
                userDB.BirthDate = user.BirthDate;
                userDB.Description = user.Description;
                userDB.Education = user.Education;
                userDB.Interest = user.Interest;
                userDB.IsExperienced = user.IsExperienced;
                userDB.IsPublic = user.IsPublic;

                unitOfWork.Users.Update(userDB);
                _ = unitOfWork.Complete();

                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }
    }
}
