using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface IChecklistRepository
    {
        ChecklistCategoryModel checklistCategoryModel { get; set; }
        ChecklistElementDetailModel checklistElementDetailModel { get; set; }
        ChecklistElementModel checklistElementModel { get; set; }
        UnitChecklistModel unitChecklistModel { get; set; }

        Task AddUnitChecklist(int unitId);
        bool CheckIfChecklistExistByUnitId(int unitId);
        Task CreateNewChecklistCategoryAsync(ChecklistCategoryModel checklistCategory, int unitId);
        Task<Guid> CreateNewChecklistDetailsElementAsync(ChecklistElementDetailModel checklistElementDetails);
        Task CreateNewChecklistElementAsync(ChecklistElementModel checklistElement);
        Task CreateNewChecklistElementDetailAsync(ChecklistElementDetailModel checklistElementDetail, Guid elementGuid);
        Task DeleteChecklistCategoryById(int categoryId);
        Task DeleteElementByIdAsync(int elementId);
        Task DeleteElementDetailsByIdAsync(Guid elementDetailsGuid);
        Task DeleteUnitChecklist(int unitId);
        Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesAsync();
        IList<ChecklistCategoryModel> GetAllChecklistCategoriesByUnitId(int unitId);
        Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesByUnitIdAsync(int unitId);
        Task<IList<ChecklistElementDetailModel>> GetAllChecklistElementDetailsAsync();
        Task<IList<ChecklistElementModel>> GetAllChecklistElementsAsync();
        Task<IList<ChecklistElementModel>> GetAllChecklistElementsByCategoryIdAsync(int categoryId);
        List<ChecklistElementDetailModel> GetAllElementDetailsListAsync(Guid unitId);
        Task<List<ChecklistBuilderModel>> GetAllUnitCategoriesAndSubElementsAsync(int unitId);
        Task<ChecklistCategoryModel> GetSingleChecklistCategoryByIdAsync(int Id);
        Task<ChecklistElementModel> GetSingleElementByIdAsync(Guid elementGuid);
        Task<ChecklistElementDetailModel> GetSingleElementDetailsAsync();
        Task UpdateChecklistCategory(ChecklistCategoryModel CategoryModel);
        Task UpdateChecklistElement(ChecklistElementModel elementModel);
        Task UpdateChecklistElementDatailsAsync(ChecklistElementDetailModel elementDetailsModel);
        Task UpdateUnitChecklist(int unitId);
    }
}