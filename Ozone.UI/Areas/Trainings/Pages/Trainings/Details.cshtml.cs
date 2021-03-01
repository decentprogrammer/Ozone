using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;

namespace Ozone.UI.Areas.Trainings.Pages.Trainings
{
    public class DetailsModel : PageModel
    {
        private ITrainingService _trainingService;

        public DetailsModel(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public InputModel Input { get; set; }

        public class InputModel
        {
            public int TrainingId { get; set; }

            public string CourseName { get; set; }

            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }
        public async Task<IActionResult> OnGet(int id)
        {
            var training = await _trainingService.GetTrainingById(id, includeDetails: true);
            Input = new InputModel()
            {
                TrainingId = training.TrainingId,
                CourseName = training.Course.CourseName,
                StartDate = training.StartDate.ToString("dd/MM/yyyy"),
                EndDate = training.EndDate.ToString("dd/MM/yyyy")
            };
            return Page();
        }
    }
}
