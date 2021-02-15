using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface IUserService
    {
        string GetUserFullNameByUserAndId(string UserId, ClaimsPrincipal user);
        bool GetUserRoleByUser(ClaimsPrincipal user, string role);
        Task<List<ApplicationUserModel>> GetUsers();
        Task<int> GetUserUnitId(string UserId, ClaimsPrincipal user);
        Task<string> GetUserUnitName(string UserId, ClaimsPrincipal user);
    }

    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<ApplicationUserModel>> GetUsers()
        {
            try
            {
                var users = await _repository.GetUsers();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }


        public string GetUserFullNameByUserAndId(string UserId, ClaimsPrincipal user)
        {
            try
            {
                var str = _repository.GetUserFullNameByUserAndId(UserId, user);
                return str;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }


        public async Task<string> GetUserUnitName(string UserId, ClaimsPrincipal user)
        {
            try
            {
                var str = await _repository.GetUserUnitName(UserId, user);
                return str;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }


        public async Task<int> GetUserUnitId(string UserId, ClaimsPrincipal user)
        {
            try
            {
                var userId = await _repository.GetUserUnitId(UserId, user);
                return userId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool GetUserRoleByUser(ClaimsPrincipal user, string role)
        {
            try
            {
                var userRole = _repository.GetUserRoleByUser(user, role);
                return userRole;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

    }
}
