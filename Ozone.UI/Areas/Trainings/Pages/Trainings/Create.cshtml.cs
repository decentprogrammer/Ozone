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
    public class CreateModel : PageModel
    {
        private ITrainingService _trainingService;
        private ICourseService _courseService;

        public CreateModel(ITrainingService trainingService, ICourseService courseService)
        {
            _trainingService = trainingService;
            _courseService = courseService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            //[Required]
            //[StringLength(250)]
            //[Display(Name = "Training Name")]
            //public string TrainingName { get; set; }

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
        public async Task<IActionResult> OnGet()
        {
            Input = new InputModel()
            {
                Courses = (await _courseService.GetCourses()).Select(p => SelectListFactory.Create(p))
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Training entry = new Training()
                    {
                        Course = await _courseService.GetCourseById(Input.CourseId),
                        CourseId = Input.CourseId,
                        StartDate = Input.StartDate,
                        EndDate = Input.EndDate                        
                    };

                    var status = await _trainingService.Insert(entry);
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
