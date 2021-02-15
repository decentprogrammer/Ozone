using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Task<IList<UnitCategoryModel>> GetAllUnitCategories();
        Task<IList<UnitCategoryModel>> GetAllUnitCategoriesAsync();
        Task<IList<UnitModel>> GetAllUnits();
        Task<List<UnitModel>> GetAllUnitsByParentNameAsync(string parentName);
        Task<UnitModel> GetUnitById(int Id);
        Task<UnitCategoryModel> GetUnitCategorySingleRecordByCategoryId(int Id);
        Task<IList<UnitModel>> GetUnits();
        Task<bool> UnitUpdateAsync(int Id, UnitModel unitModel);
        Task<bool> UnitModelExists(int id);
        Task<bool> RemoveUnit(int? id);
    }
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext _db;

        public UnitModel UnitModel { get; set; }
        public IList<UnitModel> UnitListModel { get; set; }
        public IList<UnitCategoryModel> UnitCategories { get; set; }

        public UnitRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateUnit(UnitModel unitModel)
        {
            try
            {
                await _db.UnitsTable.AddAsync(unitModel);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in New UnitModel Creation", ex);
            }
        }

        public async Task<bool> RemoveUnit(int? id)
        {
            try
            {
                var unit = await GetUnitById(Convert.ToInt32(id));
                _db.UnitsTable.Remove(unit);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in New UnitModel Creation", ex);
            }
        }

        public async Task<IList<UnitModel>> GetUnits()
        {
            try
            {
                var unitCount = _db.UnitsTable.Count();

                if (unitCount > 0)
                {
                    UnitListModel = await _db.UnitsTable.ToListAsync();
                }

                return UnitListModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Units Information", ex);
            }
        }

        public async Task<IList<UnitModel>> GetAllUnits()
        {
            try
            {
                var unitCount = _db.UnitsTable.Count();

                if (unitCount > 0)
                {
                    UnitListModel = await _db.UnitsTable.ToListAsync();
                }

                return UnitListModel;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Units Information", ex);
            }
        }


        public async Task<UnitModel> GetUnitById(int Id)
        {
            try
            {
                //var unit = await _db.UnitsTable.SingleAsync(c => c.Id == Id);
                var unit = await _db.UnitsTable.FirstOrDefaultAsync(c => c.Id == Id);
                return unit;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting UnitModel Information", ex);
            }
        }

        public async Task<UnitCategoryModel> GetUnitCategorySingleRecordByCategoryId(int Id)
        {
            try
            {
                var unitCategory = await _db.UnitCategoryTable.FirstOrDefaultAsync(c => c.Id == Id);
                return unitCategory;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Data", ex);
            }
        }

        public async Task<IList<UnitCategoryModel>> GetAllUnitCategoriesAsync()
        {
            try
            {
                UnitCategories = await _db.UnitCategoryTable.ToListAsync();
                return UnitCategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Data", ex);
            }
        }

        public async Task<IList<UnitCategoryModel>> GetAllUnitCategories()
        {
            try
            {
                UnitCategories = await _db.UnitCategoryTable.ToListAsync();
                return UnitCategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Data", ex);
            }
        }

        public async Task<bool> UnitUpdateAsync(int Id, UnitModel unitModel)
        {
            bool status = false;
            try
            {
                var UnitToEdit = await _db.UnitsTable.FirstOrDefaultAsync(c => c.Id == Id);

                UnitToEdit.ArabicName = unitModel.ArabicName;
                UnitToEdit.EnglishName = unitModel.EnglishName;
                UnitToEdit.NameAbbreviation = unitModel.NameAbbreviation;
                UnitToEdit.Description = unitModel.Description;
                UnitToEdit.Email = unitModel.Email;
                UnitToEdit.Mobile = unitModel.Mobile;
                UnitToEdit.Telephone = unitModel.Telephone;
                UnitToEdit.Fax = unitModel.Fax;
                UnitToEdit.InternalTel_1 = unitModel.InternalTel_1;
                UnitToEdit.InternalTel_2 = unitModel.InternalTel_2;
                UnitToEdit.Category = unitModel.Category;
                UnitToEdit.Location = unitModel.Location;
                UnitToEdit.ParentId = unitModel.ParentId;
                UnitToEdit.ParentName = unitModel.ParentName;
                UnitToEdit.PersonToCantact = unitModel.PersonToCantact;
                UnitToEdit.ResponsibleName = unitModel.ResponsibleName;


                status = (await _db.SaveChangesAsync() > 0);
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Updating UnitModel Data", ex);
            }

            

        }

        public async Task<bool> UnitModelExists(int id)
        {
            try
            {
                return (await _db.UnitsTable.AnyAsync(e => e.Id == id));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting UnitModel Information", ex);
            }
        }

        public async Task<List<UnitModel>> GetAllUnitByCategoryNameAsync(string categoryName)
        {
            try
            {
                var units = await _db.UnitsTable.Where(c => c.Category == categoryName).ToListAsync();
                return units;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Data", ex);
            }
        }

        public async Task<List<UnitModel>> GetAllUnitsByParentNameAsync(string parentName)
        {
            try
            {
                var units = await _db.UnitsTable.Where(u => u.ParentName == parentName).ToListAsync();
                return units;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Data", ex);
            }
        }
    }
}
