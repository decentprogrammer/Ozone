using Microsoft.AspNetCore.Identity;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Ozone.DAL.Repositories;

namespace Ozone.DAL.Utility
{
    public class UserWidgetsDetails
    {
        private readonly IChecklistRepository _checklist;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _user;
        //public ClaimsPrincipal User;

        //public bool ChecklistWidget;

        public UserWidgetsDetails(IChecklistRepository checklist, UserManager<IdentityUser> userManager, IUserRepository user)
        {
            _checklist = checklist;
            _userManager = userManager;
            _user = user;
        }


        public List<Widget> UserWidgetSubscription(ClaimsPrincipal user)
        {
            var userId = _userManager.GetUserId(user);
            var unitId = _user.GetUserUnitId(userId, user);

            var checklistWidget = _checklist.CheckIfChecklistExistByUnitId(unitId);

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
