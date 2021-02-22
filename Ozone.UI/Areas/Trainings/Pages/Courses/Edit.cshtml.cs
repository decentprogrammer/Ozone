using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.Models;

namespace Ozone.UI.Areas.Trainings.Pages.Courses
{
    public class EditModel : PageModel
    {
        private ICourseService _courseService;

        public EditModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public InputModel Input { get; set; }

        public class InputModel
        {
            public int CourseId { get; set; }
            [Required]
            [StringLength(250)]
            [Display(Name = "Course Name")]
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

        public async Task<IActionResult> OnPostAsync(InputModel input)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Course course = new Course()
                    {
                        CourseId = input.CourseId,
                        CourseName = input.CourseName
                    };

                    var status = await _courseService.Update(course);
                }
                return Page();
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
