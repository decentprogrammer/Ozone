using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;

namespace Ozone.UI.Areas.Trainings.Pages.Trainers
{
    public class IndexModel : PageModel
    {
        private ITrainerService _trainerService;

        public IndexModel(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [BindProperty]
        public TrainerViewModel TrainerModel { get; set; }

        public class TrainerViewModel
        {
            public int TrainerId { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string PhoneHome { get; set; }
            public string PhoneMobile { get; set; }
            public string Specialization { get; set; }
            public string Address { get; set; }
        }


        [BindProperty]
        public List<TrainerViewModel> listTrainerViewModel { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var listTrainings = await _trainerService.GetTrainers();
            if (listTrainings.Count > 0)
            {
                listTrainerViewModel = new List<TrainerViewModel>();
                foreach (var item in listTrainings)
                {
                    var model = new TrainerViewModel()
                    {
                        TrainerId = item.TrainerId,
                        Address = item.Address1,
                        Email = item.Email,
                        FullName = item.FullName,
                        PhoneHome = item.PhoneHome,
                        PhoneMobile = item.PhoneMobile,
                        Specialization = item.Specialization
                    };

                    listTrainerViewModel.Add(model);
                }
            }
            else
            {
                listTrainerViewModel = new List<TrainerViewModel>();
            }
            return Page();
        }

    }
}
