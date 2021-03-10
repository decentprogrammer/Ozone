using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.Models;

namespace Ozone.UI.Areas.Trainings.Pages.Trainers
{
    public class EditModel : PageModel
    {
        private ITrainerService _trainerService;

        public EditModel(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int TrainerId { get; set; }
            public string FullName { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Email { get; set; }
            public string PhoneHome { get; set; }
            public string PhoneMobile { get; set; }
            public string Specialization { get; set; }
        }
        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                var trainer = await _trainerService.GetTrainerById(id);

                if (trainer == null)
                {
                    return NotFound();
                }

                Input = new InputModel()
                {
                    TrainerId = trainer.TrainerId,
                    Address1 = trainer.Address1,
                    Address2 = trainer.Address2,
                    FullName = trainer.FullName,
                    Email = trainer.Email,
                    PhoneHome = trainer.PhoneHome,
                    PhoneMobile = trainer.PhoneMobile,
                    Specialization = trainer.Specialization
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
                    Trainer trainer = new Trainer()
                    {
                        TrainerId = Input.TrainerId,
                        Address1 = Input.Address1,
                        Address2 = Input.Address2,
                        FullName = Input.FullName,
                        Email = Input.Email,
                        PhoneHome = Input.PhoneHome,
                        PhoneMobile = Input.PhoneMobile,
                        Specialization = Input.Specialization
                    };

                    var status = await _trainerService.Update(trainer);
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
