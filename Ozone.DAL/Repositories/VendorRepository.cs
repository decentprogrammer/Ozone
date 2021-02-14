using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ApplicationDbContext _db;

        public VendorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<VendorDictionaryModel>> GetVendors()
        {
            try
            {
                var vendorNamesList = await _db.VendorsDictionaryTable.ToListAsync();
                return vendorNamesList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Vendor Information", ex);
            }
        }

        public int GetVendorIdByName(string vendorName)
        {
            try
            {
                var vendorId = _db.VendorsDictionaryTable.Where(c => c.VendorName == vendorName).FirstOrDefault().Id;
                return vendorId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Vendor Information", ex);
            }
        }
    }
}
