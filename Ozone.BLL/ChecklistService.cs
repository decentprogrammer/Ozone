using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface IChecklistService
    {
        Task<bool> CheckIfChecklistExistByUnitId(int unitId);
        Task CreateNewChecklistCategoryAsync(ChecklistCategoryModel checklistCategory, int unitId);
        Task<Guid> CreateNewChecklistDetailsElementAsync(ChecklistElementDetailModel checklistElementDetails);
        Task<bool> CreateNewChecklistElementAsync(ChecklistElementModel checklistElement);
        Task<bool> CreateNewChecklistElementDetailAsync(ChecklistElementDetailModel checklistElementDetail, Guid elementGuid);
        Task<bool> DeleteChecklistCategoryById(int categoryId);
        Task<bool> DeleteElementByIdAsync(int elementId);
        Task<bool> DeleteElementDetailsByIdAsync(Guid elementDetailsGuid);
        Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesAsync();
        Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesByUnitId(int unitId);
        Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesByUnitIdAsync(int unitId);
        Task<IList<ChecklistElementDetailModel>> GetAllChecklistElementDetailsAsync();
        Task<IList<ChecklistElementModel>> GetAllChecklistElementsAsync();
        Task<IList<ChecklistElementModel>> GetAllChecklistElementsByCategoryIdAsync(int categoryId);
        Task<List<ChecklistElementDetailModel>> GetAllElementDetailsListAsync(Guid unitId);
        Task<List<ChecklistBuilderModel>> GetAllUnitCategoriesAndSubElementsAsync(int unitId);
        Task<ChecklistCategoryModel> GetSingleChecklistCategoryByIdAsync(int Id);
        Task<ChecklistElementModel> GetSingleElementByIdAsync(Guid elementGuid);
        Task<ChecklistElementDetailModel> GetSingleElementDetailsAsync();
        Task<bool> UpdateChecklistCategory(ChecklistCategoryModel CategoryModel);
        Task<bool> UpdateChecklistElement(ChecklistElementModel elementModel);
        Task<bool> UpdateChecklistElementDatailsAsync(ChecklistElementDetailModel elementDetailsModel);
    }

    public class ChecklistService : IChecklistService
    {
        private IChecklistRepository _repository;

        public ChecklistService(IChecklistRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ChecklistElementDetailModel>> GetAllElementDetailsListAsync(Guid unitId)
        {
            try
            {
                var items = await _repository.GetAllElementDetailsListAsync(unitId);
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task CreateNewChecklistCategoryAsync(ChecklistCategoryModel checklistCategory, int unitId)
        {
            try
            {
                await _repository.CreateNewChecklistCategoryAsync(checklistCategory, unitId);
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<ChecklistCategoryModel> GetSingleChecklistCategoryByIdAsync(int Id)
        {
            try
            {
                var item = await _repository.GetSingleChecklistCategoryByIdAsync(Id);
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesAsync()
        {
            try
            {
                var items = await _repository.GetAllChecklistCategoriesAsync();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesByUnitIdAsync(int unitId)
        {
            try
            {
                var items = await _repository.GetAllChecklistCategoriesByUnitIdAsync(unitId);
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesByUnitId(int unitId)
        {
            try
            {
                var items = await _repository.GetAllChecklistCategoriesByUnitId(unitId);
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }


        public async Task<bool> UpdateChecklistCategory(ChecklistCategoryModel CategoryModel)
        {
            try
            {
                var status = await _repository.UpdateChecklistCategory(CategoryModel);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> DeleteChecklistCategoryById(int categoryId)
        {
            bool status = false;
            try
            {
                status = await _repository.DeleteChecklistCategoryById(categoryId);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> CreateNewChecklistElementAsync(ChecklistElementModel checklistElement)
        {
            bool status = false;
            try
            {
                status = await _repository.CreateNewChecklistElementAsync(checklistElement);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<ChecklistElementModel> GetSingleElementByIdAsync(Guid elementGuid)
        {
            try
            {
                var item = await _repository.GetSingleElementByIdAsync(elementGuid);
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> DeleteElementByIdAsync(int elementId)
        {
            try
            {
                var status = await _repository.DeleteElementByIdAsync(elementId);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IList<ChecklistElementModel>> GetAllChecklistElementsAsync()
        {
            try
            {
                var items = await _repository.GetAllChecklistElementsAsync();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IList<ChecklistElementModel>> GetAllChecklistElementsByCategoryIdAsync(int categoryId)
        {
            try
            {
                var items = await _repository.GetAllChecklistElementsByCategoryIdAsync(categoryId);
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateChecklistElement(ChecklistElementModel elementModel)
        {
            try
            {
                var status = await _repository.UpdateChecklistElement(elementModel);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> CreateNewChecklistElementDetailAsync(ChecklistElementDetailModel checklistElementDetail, Guid elementGuid)
        {
            try
            {
                var status = await _repository.CreateNewChecklistElementDetailAsync(checklistElementDetail, elementGuid);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<ChecklistElementDetailModel> GetSingleElementDetailsAsync()
        {
            try
            {
                var item = await _repository.GetSingleElementDetailsAsync();
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IList<ChecklistElementDetailModel>> GetAllChecklistElementDetailsAsync()
        {
            try
            {
                var items = await _repository.GetAllChecklistElementDetailsAsync();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<ChecklistBuilderModel>> GetAllUnitCategoriesAndSubElementsAsync(int unitId)
        {
            try
            {
                var items = await _repository.GetAllUnitCategoriesAndSubElementsAsync(unitId);
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateChecklistElementDatailsAsync(ChecklistElementDetailModel elementDetailsModel)
        {
            try
            {
                var status = await _repository.UpdateChecklistElementDatailsAsync(elementDetailsModel);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<Guid> CreateNewChecklistDetailsElementAsync(ChecklistElementDetailModel checklistElementDetails)
        {
            try
            {
                var val = await _repository.CreateNewChecklistDetailsElementAsync(checklistElementDetails);
                return val;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }


        public async Task<bool> DeleteElementDetailsByIdAsync(Guid elementDetailsGuid)
        {
            try
            {
                var status = await _repository.DeleteElementDetailsByIdAsync(elementDetailsGuid);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> CheckIfChecklistExistByUnitId(int unitId)
        {
            try
            {
                var status = await _repository.CheckIfChecklistExistByUnitId(unitId);
                return status;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

    }
}
