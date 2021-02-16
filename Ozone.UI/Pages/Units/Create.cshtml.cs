using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ozone.BLL;
using Ozone.DAL.Repositories;
using Ozone.Models;

namespace Ozone.UI.Pages.Units
{
    public class CreateModel : PageModel
    {
        private IUnitService _unitService;

        public CreateModel(IUnitService unitService)
        {
            _unitService = unitService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UnitModel UnitModel { get; set; }
        

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostCreateUnitAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        //return Page();
        //    }
                       

        //    return RedirectToPage("./Index");
        //}
    }
}
