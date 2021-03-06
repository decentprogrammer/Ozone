﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{

    public interface IUserRepository
    {
        string GetUserFullNameByUserAndId(string UserId, ClaimsPrincipal user);
        bool GetUserRoleByUser(ClaimsPrincipal user, string role);
        Task<List<ApplicationUserModel>> GetUsers();
        Task<int> GetUserUnitId(string UserId, ClaimsPrincipal user);
        Task<string> GetUserUnitName(string UserId, ClaimsPrincipal user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitRepository _unit;

        public UserRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager, IUnitRepository unit)
        {
            _db = db;
            _userManager = userManager;
            _unit = unit;
        }

        public async Task<List<ApplicationUserModel>> GetUsers()
        {
            try
            {
                var users = await _db.ApplicationUsersTable.ToListAsync();
                return users;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Fetching Users Information from Database", ex);
            }
        }

        public string GetUserFullNameByUserAndId(string UserId, ClaimsPrincipal user)
        {
            try
            {
                var userId = _userManager.GetUserId(user);

                var firstName = _db.ApplicationUsersTable.Where(c => c.Id == UserId).FirstOrDefault().FirstName;
                var middleName = _db.ApplicationUsersTable.Where(c => c.Id == UserId).FirstOrDefault().MiddleName;
                var lastName = _db.ApplicationUsersTable.Where(c => c.Id == UserId).FirstOrDefault().LastName;

                var fullName = firstName + " " + middleName.Substring(0, 1).ToUpper().ToString() + " " + lastName;

                return fullName;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Fetching User Information from Database", ex);
            }
        }



        public async Task<string> GetUserUnitName(string UserId, ClaimsPrincipal user)
        {
            try
            {
                var userId = _userManager.GetUserId(user);

                var unitId = _db.ApplicationUsersTable.Where(c => c.Id == UserId).FirstOrDefault().UnitId;
                var unitName = await _unit.GetUnitById(unitId);

                return unitName.EnglishName;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Fetching User Information", ex);
            }
        }

        public async Task<int> GetUserUnitId(string UserId, ClaimsPrincipal user)
        {
            try
            {
                var userId = _userManager.GetUserId(user);

                var unitId = (await _db.ApplicationUsersTable.Where(c => c.Id == UserId).FirstOrDefaultAsync()).UnitId;

                return unitId;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Fetching User Information", ex);
            }
        }



        public bool GetUserRoleByUser(ClaimsPrincipal user, string role)
        {
            try
            {
                var userRole = user.IsInRole(role);

                return userRole;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Fetching User Information", ex);
            }
        }

    }
}
