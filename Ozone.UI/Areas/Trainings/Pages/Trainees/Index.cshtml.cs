using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.Models;

namespace Ozone.UI.Areas.Trainings.Pages.Trainees
{
    public class IndexModel : PageModel
    {
        private ITraineeService _traineeService;

        public IndexModel(ITraineeService traineeService)
        {
            _traineeService = traineeService;
        }



        [BindProperty]
        public List<Trainee> listTrainees { get; set; }
        public async Task<IActionResult> OnGet()
        {
            listTrainees = await _traineeService.GetTrainees();

            return Page();
        }
    }
}
