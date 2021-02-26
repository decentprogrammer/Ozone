using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.Models;

namespace Ozone.UI.Areas.Trainings.Pages.Trainees
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {

        }



        [BindProperty]
        public List<Trainee> listTrainees { get; set; }
        public void OnGet()
        {
        }
    }
}
