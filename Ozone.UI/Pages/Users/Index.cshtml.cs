using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.DAL.Repositories;
using Ozone.Models;

namespace Ozone.UI.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _user;
        public IndexModel(IUserRepository user)
        {
            _user = user;
        }

        [BindProperty]
        public List<ApplicationUserModel> applicationUsersList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            applicationUsersList = await _user.GetUsersListAsync();

            return Page();
        }
    }
}