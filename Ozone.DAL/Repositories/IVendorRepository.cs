using Ozone.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface IVendorRepository
    {
        Task<List<VendorDictionaryModel>> GetVendors();
        int GetVendorIdByName(string vendorName);
    }
}