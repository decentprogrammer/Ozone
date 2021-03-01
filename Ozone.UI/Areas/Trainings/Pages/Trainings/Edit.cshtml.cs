using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ozone.BLL;
using Ozone.Models;
using Ozone.UI.Factories;

namespace Ozone.UI.Areas.Trainings.Pages.Trainings
{
    public class EditModel : PageModel
    {
        private ITrainingService _trainingService;
        private ICourseService _courseService;

        public EditModel(ITrainingService trainingService, ICourseService courseService)
        {
            _trainingService = trainingService;
            _courseService = courseService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int TrainingId { get; set; }

            [Required]
            [Display(Name = "Start Date")]
            public DateTime StartDate { get; set; }
            [Required]
            [Display(Name = "End Date")]
            public DateTime EndDate { get; set; }


            [Display(Name = "Course")]
            [Required(ErrorMessage = "{0} is required")]
            public int CourseId { get; set; }

            public IEnumerable<SelectListItem> Courses { get; set; }
        }
        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                var training = await _trainingService.GetTrainingById(id);

                if (training == null)
                {
                    return NotFound();
                }

                Input = new InputModel()
                {
                    TrainingId = training.TrainingId,
                    Courses = (await _courseService.GetCourses()).Select(p => SelectListFactory.Create(p)),
                    CourseId = training.CourseId,
                    StartDate = training.StartDate,
                    EndDate = training.EndDate
                };
                return Page();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Training training = new Training()
                    {
                        TrainingId = Input.TrainingId,
                        Course = await _courseService.GetCourseById(Input.CourseId),
                        CourseId = Input.CourseId,
                        StartDate = Input.StartDate,
                        EndDate = Input.EndDate
                    };

                    var status = await _trainingService.Update(training);
                }
                return new RedirectToPageResult("Index");
            }
            catch (OzoneException ex)
            {
                return RedirectToPage("/Error", ex.Message);
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", ex.Message);
            }

        }
    }
}
