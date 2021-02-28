using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.Models;

namespace Ozone.UI.Areas.Trainings.Pages.Trainings
{
    public class IndexModel : PageModel
    {
        private ITrainingService _trainingService;
        private ICourseService _courseService;

        public IndexModel(ITrainingService trainingService, ICourseService courseService)
        {
            _trainingService = trainingService;
            _courseService = courseService;
        }

        [BindProperty]
        public TrainingViewModel TrainingModel { get; set; }

        public class TrainingViewModel
        {
            public int TrainingId { get; set; }
            public string CourseName { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }


        [BindProperty]
        public List<TrainingViewModel> listTrainingViewModel { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var listTrainings = await _trainingService.GetTrainings();
            if (listTrainings.Count > 0)
            {
                listTrainingViewModel = new List<TrainingViewModel>();
                foreach (var item in listTrainings)
                {
                    var model = new TrainingViewModel()
                    {
                        TrainingId = item.TrainingId,
                        CourseName = (await _courseService.GetCourseById(item.CourseId)).CourseName,
                        StartDate = item.StartDate.ToString("dd/MM/yyyy"),
                        EndDate = item.EndDate.ToString("dd/MM/yyyy"),
                    };
                    listTrainingViewModel.Add(model);
                }
            }
            return Page();
        }


        public async Task<IActionResult> OnGetDelete(int id)
        {
            var training = await _trainingService.GetTrainingById(id);
            if (training == null)
            {
                return NotFound();

            }
            training.IsDeleted = 1;

            var status = await _trainingService.Update(training);

            return RedirectToPage("Index");
        }
    }
}
