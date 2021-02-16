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
using Ozone.BLL;

namespace Ozone.UI.Pages.Units
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        private IUnitService _unitService;

        //private readonly IUnitRepository _unit;

        [BindProperty]
        public EditUnitModel _inputToEditModel { get; set; }

        [BindProperty]
        public UnitModel unitDataModel { get; set; }

        [BindProperty]
        public UnitModel unitSingleModel { get; set; }

        public IList<UnitModel> unitsList { get; set; }

        public IList<UnitCategoryModel> unitCategories { get; set; }

        

        public List<SelectListItem> unitParents { get; set; }

        [BindProperty]
        public string ParentName { get; set; }

        public IndexModel(IUnitService unitService, EditUnitModel inputModel)
        {
            _unitService = unitService;
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
            unitsList = await _unitService.GetUnits();
        }

        public async Task<IActionResult> OnGetUpdatePage()
        {
            //if (UnitModel == null)
            //{
            unitsList = await _unitService.GetAllUnits();
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
            unitDataModel.ParentName = (await _unitService.GetUnitById(Convert.ToInt32(unitParentId))).EnglishName;
            unitDataModel.UnitGuId = Guid.NewGuid();

            unitDataModel.Category = ( await _unitService.GetUnitCategorySingleRecordByCategoryId(int.Parse(unitCategoryId))).CategoryName;

            await _unitService.CreateUnit(unitDataModel);

            unitsList = await _unitService.GetUnits();

            await FillUnitCategoriesAsync();
        }

      
        private async Task FillUnitsDataAfterSave()
        {
            if (unitsList == null)
            {
                unitsList = await _unitService.GetAllUnits();
            }
        }

        private async Task FillUnitCategoriesAsync()
        {
            unitCategories = await _unitService.GetAllUnitCategoriesAsync();
        }

        private async Task FillUnitCategories()
        {
            unitCategories = await _unitService.GetAllUnitCategories();
        }


        public async Task<JsonResult> OnGetDetailsAsync(int unitId)
        {
            unitDataModel = await _unitService.GetUnitById(unitId);

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
            unitSingleModel = await _unitService.GetUnitById(unitId);

            _inputToEditModel.UnitModel = unitSingleModel;
            _inputToEditModel.UnitCategories = unitCategories;
            _inputToEditModel.Units = unitsList;

            return Partial(path, _inputToEditModel);
        }

        public async Task OnPostUpdateUnitAsync(int unitId)
        {
            unitSingleModel = _inputToEditModel.UnitModel;

            await _unitService.UnitUpdateAsync(unitId, unitSingleModel);
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
