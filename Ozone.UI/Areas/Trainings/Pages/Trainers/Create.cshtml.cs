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

namespace Ozone.UI.Areas.Trainings.Pages.Trainers
{
    public class CreateModel : PageModel
    {
        private ITrainerService _trainerService;

        public CreateModel(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int TrainerId { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string PhoneHome { get; set; }
            public string PhoneMobile { get; set; }
            public string Specialization { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Trainer trainer = new Trainer()
                    {
                        Address1 = Input.Address1,
                        Address2 = Input.Address2,
                        FullName = Input.FullName,
                        Email = Input.Email,
                        IsDeleted = 0,
                        PhoneHome = Input.PhoneHome,
                        PhoneMobile = Input.PhoneMobile,
                        Specialization = Input.Specialization
                    };

                    var status = await _trainerService.Insert(trainer);
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
