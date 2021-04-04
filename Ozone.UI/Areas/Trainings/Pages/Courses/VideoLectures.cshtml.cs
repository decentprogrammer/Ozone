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
    public class VideoLecturesModel : PageModel
    {
        private IVideoService _videoService;
        private ICourseService _courseService;

        public VideoLecturesModel(IVideoService videoService, ICourseService courseService)
        {
            _videoService = videoService;
            _courseService = courseService;
        }

        [BindProperty]
        public List<Video> listCourseVideos { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            CourseId = id;
            var course = await _courseService.GetCourseById(id);
            if (course != null)
            {
                CourseName = course.CourseName;
            }
            
            listCourseVideos = await _videoService.GetVideosByCourseId(id, true);            
            return Page();
        }
    }
}
