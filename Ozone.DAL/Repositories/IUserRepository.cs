using Ozone.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface IUserRepository
    {
        string GetUserFullNameByUserAndId(string UserId, ClaimsPrincipal user);
        bool GetUserRoleByUser(ClaimsPrincipal user, string role);
        Task<List<ApplicationUserModel>> GetUsers();
        int GetUserUnitId(string UserId, ClaimsPrincipal user);
        Task<string> GetUserUnitName(string UserId, ClaimsPrincipal user);
    }
}