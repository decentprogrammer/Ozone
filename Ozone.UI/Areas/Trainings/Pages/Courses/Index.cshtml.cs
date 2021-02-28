using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.Models;

namespace Ozone.UI.Areas.Trainings.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private ICourseService _courseService;

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public List<Course> listCourses { get; set; }

        public async Task<IActionResult> OnGet()
        {
            listCourses = await _courseService.GetCourses();

            return Page();
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();

            }
            course.IsDeleted = 1;

            var status = await _courseService.Update(course);

            return RedirectToPage("Index");
        }
    }
}
