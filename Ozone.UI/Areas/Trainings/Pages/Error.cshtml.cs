using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Ozone.UI.Areas.Trainings.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public ErrorModel(string message)
        {
            ErrorMessage = message;
        }
        public string ErrorMessage { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
