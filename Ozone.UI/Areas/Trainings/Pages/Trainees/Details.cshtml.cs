using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;

namespace Ozone.UI.Areas.Trainings.Pages.Trainees
{
    public class DetailsModel : PageModel
    {
        private ITraineeService _traineeService;
        private IGenderService _genderService;

        public DetailsModel(ITraineeService traineeService, IGenderService genderService)
        {
            _traineeService = traineeService;
            _genderService = genderService;
        }
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int TraineeId { get; set; }
            public string FullName { get; set; }
            public string DoB { get; set; }
            public string Email { get; set; }
            public string PhoneHome { get; set; }
            public string PhoneMobile { get; set; }
            public string Address { get; set; }
            public string Gender { get; set; }
        }
        public async Task<IActionResult> OnGet(int id)
        {
            var trainee = await _traineeService.GetTraineeById(id, includeDetails: true);
            Input = new InputModel()
            {
                TraineeId = trainee.TraineeId,
                FullName = trainee.FullName,
                PhoneHome = trainee.PhoneHome,
                PhoneMobile = trainee.PhoneMobile,
                DoB = trainee.DoB.ToString("dd/MM/yyyy"),
                Address = trainee.Address,
                Email = trainee.Email,
                Gender = (await _genderService.GetGenderById(trainee.GenderId)).Description
            };
            return Page();
        }
    }
}
