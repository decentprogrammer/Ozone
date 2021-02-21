using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface IUnitService
    {
        Task<bool> CreateUnit(UnitModel unitModel);
        Task<List<UnitModel>> GetAllUnitByCategoryNameAsync(string categoryName);
        Task<IList<UnitCategoryModel>> GetAllUnitCategories();
        Task<IList<UnitCategoryModel>> GetAllUnitCategoriesAsync();
        Task<IList<UnitModel>> GetAllUnits();
        Task<List<UnitModel>> GetAllUnitsByParentNameAsync(string parentName);
        Task<UnitModel> GetUnitById(int Id);
        Task<UnitCategoryModel> GetUnitCategorySingleRecordByCategoryId(int Id);
        Task<IList<UnitModel>> GetUnits();
        Task<bool> UnitModelExists(int id);
        Task<bool> UnitUpdateAsync(int Id, UnitModel unitModel);
        Task<bool> RemoveUnit(int? id);
    }

    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _repository;

        public UnitService(IUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateUnit(UnitModel unitModel)
        {
            try
            {
                var status = await _repository.CreateUnit(unitModel);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> RemoveUnit(int? id)
        {
            try
            {
                var status = await _repository.RemoveUnit(id);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }


        public async Task<IList<UnitModel>> GetUnits()
        {
            try
            {
                var items = await _repository.GetUnits();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IList<UnitModel>> GetAllUnits()
        {
            try
            {
                var items = await _repository.GetAllUnits();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<UnitModel> GetUnitById(int Id)
        {
            try
            {
                var item = await _repository.GetUnitById(Id);
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<UnitCategoryModel> GetUnitCategorySingleRecordByCategoryId(int Id)
        {
            try
            {
                var unitCategory = await _repository.GetUnitCategorySingleRecordByCategoryId(Id);

                return unitCategory;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IList<UnitCategoryModel>> GetAllUnitCategoriesAsync()
        {
            try
            {
                var items = await _repository.GetAllUnitCategoriesAsync();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IList<UnitCategoryModel>> GetAllUnitCategories()
        {
            try
            {
                var items = await _repository.GetAllUnitCategories();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UnitUpdateAsync(int Id, UnitModel unitModel)
        {
            try
            {
                var status = await _repository.UnitUpdateAsync(Id, unitModel);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }

        }

        public async Task<bool> UnitModelExists(int id)
        {
            try
            {
                var status = await _repository.UnitModelExists(id);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<UnitModel>> GetAllUnitByCategoryNameAsync(string categoryName)
        {
            try
            {
                var items = await _repository.GetAllUnitByCategoryNameAsync(categoryName);
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<UnitModel>> GetAllUnitsByParentNameAsync(string parentName)
        {
            try
            {
                var items = await _repository.GetAllUnitsByParentNameAsync(parentName);
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

    }
}
