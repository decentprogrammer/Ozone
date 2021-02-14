using Ozone.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface IUnitRepository
    {
        IList<UnitCategoryModel> UnitCategories { get; set; }
        IList<UnitModel> UnitListModel { get; set; }
        UnitModel UnitModel { get; set; }

        Task<bool> CreateUnit(UnitModel unitModel);
        Task<List<UnitModel>> GetAllUnitByCategoryNameAsync(string categoryName);
        IList<UnitCategoryModel> GetAllUnitCategories();
        Task<IList<UnitCategoryModel>> GetAllUnitCategoriesAsync();
        IList<UnitModel> GetAllUnits();
        Task<List<UnitModel>> GetAllUnitsByParentNameAsync(string parentName);
        Task<UnitModel> GetUnitById(int Id);
        UnitCategoryModel GetUnitCategorySingleRecordByCategoryId(int Id);
        Task<IList<UnitModel>> GetUnits();
        Task UnitUpdateAsync(int Id, UnitModel unitModel);
    }
}