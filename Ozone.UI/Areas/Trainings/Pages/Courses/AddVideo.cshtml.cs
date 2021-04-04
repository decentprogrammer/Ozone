using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.Models;

namespace Ozone.UI.Areas.Trainings.Pages.Courses
{
    public class AddVideoModel : PageModel
    {
        private ICourseService _courseService;
        private IVideoService _videoService;

        public AddVideoModel(ICourseService courseService, IVideoService videoService)
        {
            _courseService = courseService;
            _videoService = videoService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            HttpContext.Session.SetInt32("CourseId", id);
            return Page();
        }

        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        public async Task<IActionResult> OnPostAsync(List<IFormFile> files)
        {
            try
            {
                int CourseId = (int)HttpContext.Session.GetInt32("CourseId");
                if (files != null || files.Count != 0)
                {
                    foreach (IFormFile file in files)
                    {
                        if (file == null || file.Length == 0)
                            throw new Exception("file not selected");

                        
                        var path = Path.Combine(
                                    Directory.GetCurrentDirectory(), "wwwroot", "videos",
                                    file.FileName.ToString());

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        FileInfo fileName = new FileInfo(path);

                        var course = await _courseService.GetCourseById(CourseId);
                        Video video = new Video()
                        {
                            Course = course,
                            Duration = "00:15:30",
                            IsDeleted = 0,
                            Title = file.FileName.ToString(),
                            URL = @"~\Ozone.UI\wwwroot\videos\",
                            CourseId = CourseId
                        };

                        var status = await _videoService.Insert(video);
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                return Page();
            }

        }
    }
}
