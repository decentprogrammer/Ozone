using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.DAL.Repositories;
using Ozone.Models;

namespace Ozone.UI.Pages.Users
{
    public class IndexModel : PageModel
    {
        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public List<ApplicationUserModel> applicationUsersList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            applicationUsersList = await _userService.GetUsers();

            return Page();
        }
    }
}