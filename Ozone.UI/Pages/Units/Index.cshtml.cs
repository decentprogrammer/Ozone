using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Ozone.Models;
using Ozone.DAL.Repositories;

namespace Ozone.UI.Pages.Units
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        //private readonly IUnitRepository _unit;

        [BindProperty]
        public EditUnitModel _inputToEditModel { get; set; }

        [BindProperty]
        public UnitModel unitDataModel { get; set; }

        [BindProperty]
        public UnitModel unitSingleModel { get; set; }

        public IList<UnitModel> unitsList { get; set; }

        public IList<UnitCategoryModel> unitCategories { get; set; }

        public IUnitRepository _unit { get; private set; }

        public List<SelectListItem> unitParents { get; set; }

        [BindProperty]
        public string ParentName { get; set; }

        public IndexModel(IUnitRepository unit, EditUnitModel inputModel)
        {
            _unit = unit;
            _inputToEditModel = inputModel;

            FillUnitsDataAfterSave();
            FillUnitCategories();
        }

        public async Task<IActionResult> OnGet()
        {
            await FillAllUnitsAsync();
            await FillUnitCategoriesAsync();

            return Page();
        }

        private async Task FillAllUnitsAsync()
        {
            unitsList = await _unit.GetAllUnitsAsync();
        }

        public IActionResult OnGetUpdatePage()
        {
            //if (UnitModel == null)
            //{
            unitsList = _unit.GetAllUnits();
            return Page();

            //}
        }

        public async Task OnPostCreateUnitAsync()
        {
            if (!ModelState.IsValid)
            {
                RedirectToPage("./Index");
            }

            var unitParentId = Request.Form["parentId"];
            var unitCategoryId = Request.Form["unitCategoryId"];

            unitDataModel.ParentId = int.Parse(unitParentId);
            unitDataModel.ParentName = _unit.GetUnitSingleRecordByUnitId(int.Parse(unitParentId)).EnglishName;
            unitDataModel.UnitGuId = Guid.NewGuid();

            unitDataModel.Category = _unit.GetUnitCategorySingleRecordByCategoryId(int.Parse(unitCategoryId)).CategoryName;

            await _unit.CreateNewUnitAsync(unitDataModel);

            unitsList = await _unit.GetAllUnitsAsync();

            await FillUnitCategoriesAsync();
        }

      
        private void FillUnitsDataAfterSave()
        {
            if (unitsList == null)
            {
                unitsList = _unit.GetAllUnits();
            }
        }

        private async Task FillUnitCategoriesAsync()
        {
            unitCategories = await _unit.GetAllUnitCategoriesAsync();
        }

        private void FillUnitCategories()
        {
            unitCategories = _unit.GetAllUnitCategories();
        }


        public async Task<JsonResult> OnGetDetailsAsync(int unitId)
        {
            unitDataModel = await _unit.GetUnitSingleRecordByUnitIdAsync(unitId);

            if (unitDataModel == null)
            {
                return new JsonResult(null);
            }
            return new JsonResult(unitDataModel);
        }

        //public async Task<JsonResult> OnGetUpdateUnitDataModelAsync(int unitId)
        //{
        //    UnitDataModel = await _unit.GetUnitSingleRecordByUnitIdAsync(unitId);

        //    return new JsonResult(UnitDataModel);
        //}

        public async Task<PartialViewResult> OnGetUpdateUnitDataModelAsync(int unitId)
        {
            var path = "/Pages/Units/UnitsPartials/_Edit.cshtml";
            unitSingleModel = await _unit.GetUnitSingleRecordByUnitIdAsync(unitId);

            _inputToEditModel.Unit = unitSingleModel;
            _inputToEditModel.UnitCategories = unitCategories;
            _inputToEditModel.Units = unitsList;

            return Partial(path, _inputToEditModel);
        }

        public async Task OnPostUpdateUnitAsync(int unitId)
        {
            unitSingleModel = _inputToEditModel.Unit;

            await _unit.UnitUpdateAsync(unitId, unitSingleModel);
        }


        //public JsonResult OnGetDetails(int unitId)
        //{
        //    UnitDataModel =  _unit.GetUnitSingleRecordByUnitId(unitId);

        //    if (UnitDataModel == null)
        //    {
        //        return new JsonResult(null);
        //    }

        //    return new JsonResult(UnitDataModel);
        //}


    }
}
