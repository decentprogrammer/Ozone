using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ozone.UI.Areas.Trainings.Pages.Trainees
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(250)]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

            [Required]
            [StringLength(250)]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [Display(Name = "Date of Birth")]
            public DateTime DoB { get; set; }

            [Required(ErrorMessage = "{0} is required")]
            public int GenderId { get; set; }

            public IEnumerable<SelectListItem> Gender { get; set; }

            [Required(ErrorMessage = "{0} is required")]
            public int GradeId { get; set; }
            public IEnumerable<SelectListItem> Grade { get; set; }
        }
        public void OnGet()
        {
        }
    }
}
