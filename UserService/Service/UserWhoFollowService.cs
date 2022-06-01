using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.DTO;
using UserService.Model;
using UserService.Repository;

namespace UserService.Service
{
    public class UserWhoFollowService : BaseService<UserFollow>, IUserWhoFollowService
    {
        public UserWhoFollowService(ILogger<UserService> logger) 
        {
            _logger = logger;
        }

        public UserFollow Add(UserFollowDTO dto) 
        {
            try
            {
                using UnitOfWork unitOfWork = new(new UserContext());

                User user = unitOfWork.Users.Get(dto.UserID);
                User userWhoFollow = unitOfWork.Users.Get(dto.UserWhoFollowID);

                UserFollow userFollow = new UserFollow();

                unitOfWork.UserFollows.Add(userFollow);
                _ = unitOfWork.Complete();

                unitOfWork.UserFollows.Update(userFollow);
                userFollow.User = user;
                userFollow.UserWhoFollow = userWhoFollow;

                if (userWhoFollow.IsPublic)
                {
                    userFollow.Status = UserFollowStatus.APPROVED;
                }
                else 
                {
                    userFollow.Status = UserFollowStatus.WAITING;
                }

                _ = unitOfWork.Complete();

                return userFollow;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Add Method { e.Message} in { e.StackTrace}");
                return null;
            }
        }

        public UserFollow Approve(long id) 
        {
            try
            {
                using UnitOfWork unitOfWork = new(new UserContext());

                UserFollow userFollow = unitOfWork.UserFollows.Get(id);


                unitOfWork.UserFollows.Update(userFollow);
                userFollow.Status = UserFollowStatus.APPROVED;
                
                _ = unitOfWork.Complete();

                return userFollow;
            }

            catch (Exception e)
            {
                _logger.LogError($"Error in BaseService in Add Method { e.Message} in { e.StackTrace}");
                return null;
            }
        }

        public IEnumerable<UserFollow> GetAllUserFollowers(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new UserContext());

                return unitOfWork.UserFollows.GetAllUserFollowers(id);
            }
            catch (Exception e)
            { 
                return new List<UserFollow>();
            }
        }

        public IEnumerable<UserFollow> GetAllUserApproveFollowers(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new UserContext());

                return unitOfWork.UserFollows.GetAllUserApproveFollowers(id);
            }
            catch (Exception e)
            {
                return new List<UserFollow>();
            }
        }

        public UserFollow Reject(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new(new UserContext());

                UserFollow userFollow = unitOfWork.UserFollows.Get(id);

                unitOfWork.UserFollows.Update(userFollow);
                userFollow.Status = UserFollowStatus.REJECTED;

                _ = unitOfWork.Complete();
                return userFollow;

            }
            catch (Exception e)
            {
                _logger.LogError($"Error is BAseSErvice in Add Method { e.Message} in {e.StackTrace}");
                return null;
            }
        }
        
    }
}
