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

        void CreateNewUnit(UnitModel unitModel);
        Task CreateNewUnitAsync(UnitModel unitModel);
        Task<List<UnitModel>> GetAllUnitByCategoryNameAsync(string categoryName);
        IList<UnitCategoryModel> GetAllUnitCategories();
        Task<IList<UnitCategoryModel>> GetAllUnitCategoriesAsync();
        IList<UnitModel> GetAllUnits();
        Task<IList<UnitModel>> GetAllUnitsAsync();
        Task<List<UnitModel>> GetAllUnitsByParentNameAsync(string parentName);
        UnitCategoryModel GetUnitCategorySingleRecordByCategoryId(int Id);
        UnitModel GetUnitSingleRecordByUnitId(int Id);
        Task<UnitModel> GetUnitSingleRecordByUnitIdAsync(int Id);
        Task UnitUpdateAsync(int Id, UnitModel unitModel);
    }
}