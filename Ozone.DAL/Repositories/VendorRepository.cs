﻿using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface IVendorRepository
    {
        Task<int> GetVendorIdByName(string vendorName);
        Task<List<VendorDictionaryModel>> GetVendors();
    }

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
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Vendor Information", ex);
            }
        }

        public async Task<int> GetVendorIdByName(string vendorName)
        {
            try
            {
                var vendorId = (await _db.VendorsDictionaryTable.Where(c => c.VendorName == vendorName).FirstOrDefaultAsync()).Id;
                return vendorId;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Vendor Information", ex);
            }
        }
    }
}
