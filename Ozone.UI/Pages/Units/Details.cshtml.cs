using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;

namespace Ozone.UI.Pages.Units
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public UnitModel UnitModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UnitModel = await _context.UnitsTable.FirstOrDefaultAsync(m => m.Id == id);

            if (UnitModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
