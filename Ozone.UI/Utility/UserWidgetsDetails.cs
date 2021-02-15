using Microsoft.AspNetCore.Identity;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Ozone.DAL.Repositories;
using Ozone.BLL;

namespace Ozone.UI.Utility
{
    public class UserWidgetsDetails
    {
        private readonly IChecklistService _checklistService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserService _userService;

        //public ClaimsPrincipal User;

        //public bool ChecklistWidget;

        public UserWidgetsDetails(IChecklistService checklistService, UserManager<IdentityUser> userManager, IUserService userService)
        {
            _checklistService = checklistService;
            _userManager = userManager;
            _userService = userService;
        }


        public async Task<List<Widget>> UserWidgetSubscription(ClaimsPrincipal user)
        {
            var userId = _userManager.GetUserId(user);
            var unitId = await _userService.GetUserUnitId(userId, user);

            var checklistWidget = await _checklistService.CheckIfChecklistExistByUnitId(unitId);

            var widget = new List<Widget>() {
            new Widget{ChecklistWidget = checklistWidget}
            };

            return widget;
        }

        public class Widget
        {
            public bool ChecklistWidget { get; set; }
        }

    }
}
