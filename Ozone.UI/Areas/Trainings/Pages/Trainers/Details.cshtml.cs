using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;

namespace Ozone.UI.Areas.Trainings.Pages.Trainers
{
    public class DetailsModel : PageModel
    {
        private ITrainerService _trainerService;

        public DetailsModel(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int TrainerId { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string PhoneHome { get; set; }
            public string PhoneMobile { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
        }
        public async Task<IActionResult> OnGet(int id)
        {
            var trainer = await _trainerService.GetTrainerById(id, includeDetails: true);
            Input = new InputModel()
            {
               FullName = trainer.FullName,
               Email = trainer.Email,
               PhoneHome = trainer.PhoneHome,
               PhoneMobile = trainer.PhoneMobile,
               Address1 = trainer.Address1,
               Address2 = trainer.Address2
            };
            return Page();
        }
    }
}
