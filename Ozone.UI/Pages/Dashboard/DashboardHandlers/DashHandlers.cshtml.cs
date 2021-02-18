using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.BLL;
using Ozone.DAL.Repositories;

namespace Ozone.UI.Pages.Dashboard.DashboardHandlers
{
    public class DashHandlersModel : PageModel
    {
        private IVendorService _vendorService;
        private IChecklistService _checklistService;

        public DashHandlersModel(IVendorService vendorService, IChecklistService checklistService)
        {
            _vendorService = vendorService;
            _checklistService = checklistService;
        }

        public async Task<JsonResult> OnGetGetVendorModelByVendorIdAsync(int vendorId)
        {
            var vendorModelList = await _vendorService.GetVendors();

            var vendorModel = vendorModelList.Where(c => c.Id == vendorId).FirstOrDefault();

            return new JsonResult(vendorModel);
        }



        public void OnGet()
        {
        }
    }
}
