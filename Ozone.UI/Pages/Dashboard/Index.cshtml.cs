using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ozone.Models;
using System.Security.Claims;
using static Ozone.DAL.Utility.UserWidgetsDetails;
using Ozone.DAL.Utility;
using Ozone.DAL.Repositories;

namespace Ozone.UI.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _user;
        private readonly IUnitRepository _unit;
        private readonly IChecklistRepository _checklist;
        private readonly UserWidgetsDetails _userWidgetsDetails;

        [ViewData]
        public string Message { get; set; }
        [ViewData]
        public string Action { get; set; }
        public string userFullName { get; set; }
        public string userRole { get; set; }
        public string unitName { get; set; }
        public int unitId { get; set; }
        public int elementID { get; set; }
        public int elementDetailsId { get; set; }


        [BindProperty]
        public ChecklistElementDetailModel ChecklistElementDetailsModel { get; set; }

        public List<Widget> WidgetList { get; set; }

        public IndexModel(UserManager<IdentityUser> userManager, IUserRepository user, IUnitRepository unit, IChecklistRepository checklist, UserWidgetsDetails userWidgetsDetails)
        {
            _userManager = userManager;
            _user = user;
            _unit = unit;
            _checklist = checklist;
            _userWidgetsDetails = userWidgetsDetails;
        }

        public void OnGet()
        {
            UserDetails();
            WidgetList = _userWidgetsDetails.UserWidgetSubscription(User);
        }

        public void UserAuthorizationByRole()
        {
            if (_user.GetUserRoleByUser(User, StaticDetails.Administrator))
            {
                userRole = StaticDetails.Administrator;
            }
            else if (_user.GetUserRoleByUser(User, StaticDetails.Admin))
            {
                userRole = StaticDetails.Admin;
            }
            else if (_user.GetUserRoleByUser(User, StaticDetails.Manager))
            {
                userRole = StaticDetails.Manager;
            }
            else if (_user.GetUserRoleByUser(User, StaticDetails.User))
            {
                userRole = StaticDetails.User;
            }
            else if (_user.GetUserRoleByUser(User, StaticDetails.Guest))
            {
                userRole = StaticDetails.Guest;
            }
        }

        public async Task UserDetails()
        {
            var uId = _userManager.GetUserId(User);
            var fullName = _user.GetUserFullNameByUserAndId(uId, User);
            userFullName = fullName;

            unitName = await _user.GetUserUnitName(uId, User);
            unitId = _user.GetUserUnitId(uId, User);
        }

        public PartialViewResult OnGetChecklistModal()
        {
            var checklist = Partial("Pages/Manage/ManagePartials/_ChecklistModal.cshtml");
            return checklist;
        }

        public PartialViewResult OnGetCardsPartial()
        {
            var cardsPartials = Partial("Pages/Dashboard/DashboardPartials/_CardsPartial.cshtml");
            return cardsPartials;
        }

        public async Task<JsonResult> OnPostCreateNewElementDetailAsync()
        {
            var newGuid = await _checklist.CreateNewChecklistDetailsElementAsync(ChecklistElementDetailsModel);
            return new JsonResult(newGuid);
        }



        public async Task<JsonResult> OnPostUpdateElementDeatilAsync()
        {
            var status = ChecklistElementDetailsModel.Status;
            bool finalStatus = false;

            // ChecklistElementDetailsModel.ElementId = eId;

            //var fs = ChecklistElementDetailsModel.FinalStatus;
            if (status == "Great")
            {
                ChecklistElementDetailsModel.FinalStatus = true;
                finalStatus = true;
            }


            await _checklist.UpdateChecklistElementDatailsAsync(ChecklistElementDetailsModel);

            UserDetails();
            WidgetList = _userWidgetsDetails.UserWidgetSubscription(User);
            return new JsonResult(finalStatus);
        }

        public async Task<JsonResult> OnGetGetElementDetailsByIdAsync(Guid elmntDetailId)
        {
            var elementDetails = await _checklist.GetSingleElementDetailsAsync();
            return new JsonResult(elementDetails);
        }
    }
}