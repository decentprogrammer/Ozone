using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface IVendorService
    {
        Task<int> GetVendorIdByName(string vendorName);
        Task<List<VendorDictionaryModel>> GetVendors();
    }

    public class VendorService : IVendorService
    {
        private IVendorRepository _repository;

        public VendorService(IVendorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VendorDictionaryModel>> GetVendors()
        {
            try
            {
                var items = await _repository.GetVendors();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<int> GetVendorIdByName(string vendorName)
        {
            try
            {
                var id = await _repository.GetVendorIdByName(vendorName);
                return id;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

    }
}
