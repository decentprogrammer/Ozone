using Ozone.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface IVendorRepository
    {
        Task<int> GetVendorIdByName(string vendorName);
        Task<List<VendorDictionaryModel>> GetVendors();
    }
}