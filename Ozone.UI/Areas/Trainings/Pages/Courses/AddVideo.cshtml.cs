using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ozone.UI.Areas.Trainings.Pages.Courses
{
    public class AddVideoModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return Content("file not selected");

                //var path = Path.Combine(
                //            Directory.GetCurrentDirectory(), "wwwroot",
                //            file.FileName.ToString());

                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot", "videos",
                            file.FileName.ToString());

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                FileInfo fileName = new FileInfo(path);


                //ViewBag.Message = "File Imported Successfully";

                return Page();
            }
            catch (Exception ex)
            {


                return Page();
            }

        }
    }
}
