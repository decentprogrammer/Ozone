using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.DAL.Repositories;

namespace Ozone.UI.Pages.GeneralHandlers
{
    public class GeneralModel : PageModel
    {
        private IUnitService _unitService;

        public GeneralModel(IUnitService unitService)
        {
            _unitService = unitService;
        }
        public void OnGet(){}

        public async Task<JsonResult> OnGetGetAllUnitCategoriesAsync()
        {
            var categories = await _unitService.GetAllUnitCategoriesAsync();

            return new JsonResult(categories);
        }

        public async Task<JsonResult> OnGetGetAllUnitsAsync()
        {
            var units = await _unitService.GetUnits();

            return new JsonResult(units);
        }

        public async Task<JsonResult> OnGetGetUnitListByCategoryNameAsync(string categoryName)
        {
            var units = await _unitService.GetAllUnitByCategoryNameAsync(categoryName);
            return new JsonResult(units);
        }

        public async Task<JsonResult> OnGetGetUnitListByParentNameAsync(string parentName)
        {
            var units = await _unitService.GetAllUnitsByParentNameAsync(parentName);
            return new JsonResult(units);
        }



    }
}