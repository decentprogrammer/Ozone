using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ozone.BLL;
using Ozone.DAL;
using Ozone.Models;

namespace Ozone.UI.Pages.Units
{
    public class EditModel : PageModel
    {
        private IUnitService _unitService;

        public EditModel(IUnitService unitService)
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

            //UnitModel = await _context.UnitsTable.FirstOrDefaultAsync(m => m.Id == id);
            UnitModel = await _unitService.GetUnitById(Convert.ToInt32(id));

            if (UnitModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(UnitModel).State = EntityState.Modified;

            //try
            //{
                
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!(await _unitService.UnitModelExists(UnitModel.Id)))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        private async Task<bool> UnitModelExists(int id)
        {
            return await _unitService.UnitModelExists(id);
            //return _context.UnitsTable.Any(e => e.Id == id);
        }
    }
}
