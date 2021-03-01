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

namespace Ozone.UI.Areas.Trainings.Pages.Trainees
{
    public class CreateModel : PageModel
    {
        private ITraineeService _traineeService;
        private IGenderService _genderService;

        public CreateModel(ITraineeService traineeService, IGenderService genderService)
        {
            _traineeService = traineeService;
            _genderService = genderService;
        }

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
            [StringLength(50)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Date of Birth")]
            public DateTime DoB { get; set; }

            [Required(ErrorMessage = "{0} is required")]
            public int GenderId { get; set; }

            public IEnumerable<SelectListItem> Gender { get; set; }

           
        }
        public async Task<IActionResult> OnGet()
        {
            Input = new InputModel()
            {
                Gender = (await _genderService.GetGenders()).Select(p => SelectListFactory.Create(p))
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Trainee trainee = new Trainee()
                    {
                        FullName = Input.FullName,
                        Email = Input.Email,
                        DoB = Input.DoB,
                        GenderId = Input.GenderId,
                        Address = Input.Address,
                        IsDeleted = 0,
                        Gender = await _genderService.GetGenderById(Input.GenderId)
                    };

                    var status = await _traineeService.Insert(trainee);
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
