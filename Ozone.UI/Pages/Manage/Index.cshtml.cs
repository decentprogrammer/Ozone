using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.DAL.Repositories;
using Ozone.Models;

namespace Ozone.UI.Pages.Manage
{
    public class IndexModel : PageModel
    {

        private readonly IChecklistRepository _checklist;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IVendorService _vendorService;

        public int userUnitId { get; set; }

        public IndexModel(IChecklistRepository checklist, IUserService userService, UserManager<IdentityUser> userManager, IVendorService vendor)
        {
            _checklist = checklist;
            _userService = userService;
            _userManager = userManager;
            _vendorService = vendor;
        }

        public IActionResult OnGet()
        {
            GetUserUnitId();

            return Page();
        }

        private async Task GetUserUnitId()
        {
            var userId = _userManager.GetUserId(User);

            userUnitId = await _userService.GetUserUnitId(userId, User);
        }


        // Categroies methods

        public IList<ChecklistCategoryModel> categoriesList { get; set; }

        [BindProperty]
        public ChecklistCategoryModel categoryModel { get; set; }

        public async Task OnPostCreateCategoryAsync()
        {
            var uid = userUnitId;

            Guid guId = Guid.NewGuid();

            categoryModel.HelpId = guId;

            //var publicVisibility = Request.Form["Visibility"];

            //categoryModel.PublicVisible = bool.Parse(publicVisibility);

            var catModel = categoryModel;

            await _checklist.CreateNewChecklistCategoryAsync(catModel, uid);

        }

        public async Task OnPostDeleteCategoryAsync(int categoryId)
        {
            await _checklist.DeleteChecklistCategoryById(categoryId);
        }

        public async Task OnPostUpdateCategoryAsync()
        {
            await _checklist.UpdateChecklistCategory(categoryModel);
        }

        public async Task<JsonResult> OnGetGetSingleCategoryAsync(int categoryId)
        {
            var category = await _checklist.GetSingleChecklistCategoryByIdAsync(categoryId);
            return new JsonResult(category);
        }

        public async Task<JsonResult> OnGetAllUnitCategoriesAsync(int unitId)
        {
            categoriesList = await _checklist.GetAllChecklistCategoriesByUnitIdAsync(unitId);
            return new JsonResult(categoriesList);
        }

        public async Task<JsonResult> OnGetAllUnitCategoriesForChecklistModalAsync(int unitId)
        {
            categoriesList = await _checklist.GetAllChecklistCategoriesByUnitIdAsync(unitId);

            List<ChecklistCategoryModel> categoryModelsList = new List<ChecklistCategoryModel>();

            foreach (var cat in categoriesList)
            {
                var elements = await _checklist.GetAllChecklistElementsByCategoryIdAsync(cat.Id);

                if (elements.Count > 0)
                {
                    categoryModelsList.Add(cat);
                }
            }

            return new JsonResult(categoryModelsList);
        }


        // Elements methods


        public IList<ChecklistElementModel> elementsList { get; set; }

        [BindProperty]
        public ChecklistElementModel elementModel { get; set; }

        public async Task OnPostCreateElementAsync()
        {

            Guid guId = Guid.NewGuid();

            elementModel.HelpId = guId;

            // Setting Initial Value for element Progress

            elementModel.ProcessStatus = "None";

            var elmntModel = elementModel;

            elmntModel.Id = 0;

            await _checklist.CreateNewChecklistElementAsync(elmntModel);

        }



        public async Task OnPostUpdateElementAsync()
        {
            DateTime instDate = Convert.ToDateTime(Request.Form["Element-Installed"]);
            DateTime rplcDate = Convert.ToDateTime(Request.Form["Element-Replace"]);

            elementModel.Installed = instDate;
            elementModel.Replace = rplcDate;

            await _checklist.UpdateChecklistElement(elementModel);
        }

        public async Task OnPostDeleteElementAsync(int elementId)
        {
            await _checklist.DeleteElementByIdAsync(elementId);
        }

        public async Task<JsonResult> OnGetGetSingleElementByIdAsync(Guid elementId)
        {

            var vendorName = await _vendorService.GetVendors();

            var elementModel = await _checklist.GetSingleElementByIdAsync(elementId);

            var name = vendorName.Where(c => c.Id == elementModel.VendorId).FirstOrDefault().VendorName;
            elementModel.VendorName = name;

            return new JsonResult(elementModel);
        }

        public async Task<JsonResult> OnGetAllElementsByCategoryIdAsync(int categoryId)
        {
            var elementsList = await _checklist.GetAllChecklistElementsByCategoryIdAsync(categoryId);

            return new JsonResult(elementsList);
        }

        public async Task<JsonResult> OnGetAllUnitCategoriesAndSubElementsAsync()
        {


            var elementsList = await _checklist.GetAllUnitCategoriesAndSubElementsAsync(userUnitId);

            return new JsonResult(elementsList);
        }


        public async Task<JsonResult> OnGetElementDetailsIdAsync(Guid elementId)
        {
            var elementDetails = await _checklist.GetSingleElementDetailsAsync();
            return new JsonResult(elementDetails);
        }

        public async Task<JsonResult> OnGetAllVendorsNamsListAsync()
        {
            var vendorsNames = await _vendorService.GetVendors();
            return new JsonResult(vendorsNames);
        }

        public async Task<JsonResult> OnGetGetVendorId(string vendorName)
        {
            var vendorId = await _vendorService.GetVendorIdByName(vendorName);
            return new JsonResult(vendorId);
        }

    }
}