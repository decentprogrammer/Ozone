using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ozone.DAL.Repositories;

namespace Ozone.UI.Pages.Dashboard.DashboardHandlers
{
    public class DashHandlersModel : PageModel
    {

        public IVendorRepository _Vendor { get; }
        public IChecklistRepository _Checklist { get; }

        public DashHandlersModel(IVendorRepository vendor, IChecklistRepository checklist)
        {
            _Vendor = vendor;
            _Checklist = checklist;
        }

        public async Task<JsonResult> OnGetGetVendorModelByVendorIdAsync(int vendorId)
        {
            var vendorModelList = await _Vendor.GetVendors();

            var vendorModel = vendorModelList.Where(c => c.Id == vendorId).FirstOrDefault();

            return new JsonResult(vendorModel);
        }



        public void OnGet()
        {
        }
    }
}
