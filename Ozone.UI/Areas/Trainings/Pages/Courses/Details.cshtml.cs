using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;

namespace Ozone.UI.Areas.Trainings.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private ICourseService _courseService;

        public DetailsModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int CourseId { get; set; }
                       
            public string CourseName { get; set; }
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var course = await _courseService.GetCourseById(id);

            Input = new InputModel()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName
            };
            return Page();
        }
    }
}
