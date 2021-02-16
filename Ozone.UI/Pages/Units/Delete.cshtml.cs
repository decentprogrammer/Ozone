using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ozone.BLL;
using Ozone.DAL;
using Ozone.Models;

namespace Ozone.UI.Pages.Units
{
    public class DeleteModel : PageModel
    {
        private IUnitService _unitService;

        public DeleteModel(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [BindProperty]
        public UnitModel UnitModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UnitModel = await _unitService.GetUnitById(Convert.ToInt32(id));

            if (UnitModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool status = await _unitService.RemoveUnit(id);

            return RedirectToPage("./Index");
        }
    }
}
