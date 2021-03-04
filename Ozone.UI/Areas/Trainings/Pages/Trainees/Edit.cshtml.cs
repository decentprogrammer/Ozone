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
    public class EditModel : PageModel
    {
        private ITraineeService _traineeService;
        private IGenderService _genderService;

        public EditModel(ITraineeService traineeService, IGenderService genderService)
        {
            _traineeService = traineeService;
            _genderService = genderService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int TraineeId { get; set; }
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
            [StringLength(50)]
            [Display(Name = "Home Phone")]
            public string PhoneHome { get; set; }

            [Required]
            [StringLength(50)]
            [Display(Name = "Cell Number")]
            public string PhoneMobile { get; set; }


            [Required]
            [Display(Name = "Date of Birth")]
            public DateTime DoB { get; set; }

            [Required(ErrorMessage = "{0} is required")]
            public int GenderId { get; set; }

            public IEnumerable<SelectListItem> Gender { get; set; }

           
        }
        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                var trainee = await _traineeService.GetTraineeById(id);

                if (trainee == null)
                {
                    return NotFound();
                }

                Input = new InputModel()
                {
                    TraineeId = trainee.TraineeId,                    
                    Address = trainee.Address,
                    DoB = trainee.DoB,
                    Email = trainee.Email,
                    PhoneHome = trainee.PhoneHome,
                    PhoneMobile = trainee.PhoneMobile,
                    FullName = trainee.FullName,
                    GenderId = trainee.GenderId,
                    Gender = (await _genderService.GetGenders()).Select(p => SelectListFactory.Create(p))
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
                    Trainee trainee = new Trainee()
                    {
                        TraineeId = Input.TraineeId,
                        Gender = await _genderService.GetGenderById(Input.GenderId),
                        GenderId = Input.GenderId,
                        Address = Input.Address,
                        DoB = Input.DoB,
                        Email = Input.Email,
                        PhoneHome = Input.PhoneHome,
                        PhoneMobile = Input.PhoneMobile,
                        FullName = Input.FullName
                    };

                    var status = await _traineeService.Update(trainee);
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
