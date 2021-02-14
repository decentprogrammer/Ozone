using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.DAL.Repositories;

namespace Ozone.UI.Pages.GeneralHandlers
{
    public class GeneralModel : PageModel
    {
        private readonly IUnitRepository _unit;

        public GeneralModel(IUnitRepository unit)
        {
            _unit = unit;
        }
        public void OnGet(){}

        public async Task<JsonResult> OnGetGetAllUnitCategoriesAsync()
        {
            var categories = await _unit.GetAllUnitCategoriesAsync();

            return new JsonResult(categories);
        }

        public async Task<JsonResult> OnGetGetAllUnitsAsync()
        {
            var units = await _unit.GetUnits();

            return new JsonResult(units);
        }

        public async Task<JsonResult> OnGetGetUnitListByCategoryNameAsync(string categoryName)
        {
            var units = await _unit.GetAllUnitByCategoryNameAsync(categoryName);
            return new JsonResult(units);
        }

        public async Task<JsonResult> OnGetGetUnitListByParentNameAsync(string parentName)
        {
            var units = await _unit.GetAllUnitsByParentNameAsync(parentName);
            return new JsonResult(units);
        }



    }
}