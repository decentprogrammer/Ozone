using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ozone.DAL;
using Ozone.DAL.Hubs;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public class ChecklistRepository : IChecklistRepository
    {

        public ChecklistCategoryModel checklistCategoryModel { get; set; }

        public ChecklistElementModel checklistElementModel { get; set; }

        public ChecklistElementDetailModel checklistElementDetailModel { get; set; }


        private readonly ApplicationDbContext _db;
        private readonly IHubContext<SignalDashboard> _hubContext;
        private string connectionString = "";

        public ChecklistRepository(ApplicationDbContext db, IConfiguration configuration, IHubContext<SignalDashboard> hubContext)
        {
            _db = db;
            connectionString = configuration.GetConnectionString("DefaultConnection");
            _hubContext = hubContext;

        }


        // Checklist update dashboard

        public List<ChecklistElementDetailModel> GetAllElementDetailsListAsync(Guid unitId)
        {
            try
            {
                var elemntDetails = new List<ChecklistElementDetailModel>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlDependency.Start(connectionString);

                    string commandText = "select Status from dbo.ChecklistElementDetailsTable where Status <> 'Great'";

                    SqlCommand cmd = new SqlCommand(commandText, conn);

                    SqlDependency dependency = new SqlDependency(cmd);

                    dependency.OnChange += new OnChangeEventHandler(dbChangeNotification);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //var employee = new Employee
                        //{
                        //    Id = Convert.ToInt32(reader["Id"]),
                        //    Name = reader["Name"].ToString(),
                        //    Age = Convert.ToInt32(reader["Age"])
                        //};

                        //elemntDetails.Add(employee);
                    }
                }

                return elemntDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Element Details from Database", ex);
            }
        }

        private void dbChangeNotification(object sender, SqlNotificationEventArgs e)
        {
            _hubContext.Clients.All.SendAsync("refreshEmployees");
        }

        // Checklist Categories Section

        public async Task CreateNewChecklistCategoryAsync(ChecklistCategoryModel checklistCategory, int unitId)
        {
            try
            {
                checklistCategory.UnitChecklistId = unitId;
                await _db.ChecklistCategoriesTable.AddAsync(checklistCategory);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Creating New Checklist Category", ex);
            }
        }

        public async Task<ChecklistCategoryModel> GetSingleChecklistCategoryByIdAsync(int Id)
        {
            try
            {
                checklistCategoryModel = await _db.ChecklistCategoriesTable.FirstOrDefaultAsync(c => c.Id == Id);
                return (checklistCategoryModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Checklist Data from database", ex);
            }
        }

        public async Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesAsync()
        {
            try
            {
                var checklistCategories = await _db.ChecklistCategoriesTable.ToListAsync();
                return (checklistCategories);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Checklist Data from database", ex);
            }
        }

        public async Task<IList<ChecklistCategoryModel>> GetAllChecklistCategoriesByUnitIdAsync(int unitId)
        {
            try
            {
                var checklistCategories = await _db.ChecklistCategoriesTable.Where(c => c.UnitChecklistId == unitId).ToListAsync();
                return checklistCategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Checklist Data from Database", ex);
            }
        }

        public IList<ChecklistCategoryModel> GetAllChecklistCategoriesByUnitId(int unitId)
        {
            try
            {
                var checklistCategories = _db.ChecklistCategoriesTable.Where(c => c.UnitChecklistId == unitId).ToList();
                return checklistCategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Checklist Data from Database", ex);
            }
        }

        public async Task UpdateChecklistCategory(ChecklistCategoryModel CategoryModel)
        {
            try
            {
                await GetSingleChecklistCategoryByIdAsync(CategoryModel.Id);
                //
                checklistCategoryModel.Name = CategoryModel.Name;
                checklistCategoryModel.PublicVisible = CategoryModel.PublicVisible;
                checklistCategoryModel.Description = CategoryModel.Description;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Updating Checklist Data in Database", ex);
            }
        }

        public async Task DeleteChecklistCategoryById(int categoryId)
        {
            try
            {
                checklistCategoryModel = await _db.ChecklistCategoriesTable.FindAsync(categoryId);

                var categorySubElements = await GetAllChecklistElementsByCategoryIdAsync(categoryId);

                if (categorySubElements.Count > 0)
                {
                    _db.ChecklistElementsTable.RemoveRange(categorySubElements);
                }

                if (checklistCategoryModel != null)
                {
                    _db.ChecklistCategoriesTable.Remove(checklistCategoryModel);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Deleting Checklist data from Database", ex);
            }            
        }

        // Checklist Elements Section

        public async Task CreateNewChecklistElementAsync(ChecklistElementModel checklistElement)
        {
            try
            {
                await _db.ChecklistElementsTable.AddAsync(checklistElement);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Creating Checklist Data", ex);
            }
        }

        public async Task<ChecklistElementModel> GetSingleElementByIdAsync(Guid elementGuid)
        {
            try
            {
                checklistElementModel = await _db.ChecklistElementsTable.FirstOrDefaultAsync(c => c.GuidId == elementGuid);
                return (checklistElementModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Element Data from Database", ex);
            }
        }

        public async Task DeleteElementByIdAsync(int elementId)
        {
            try
            {
                var checklistElement = await _db.ChecklistElementsTable.FindAsync(elementId);

                if (checklistElement != null)
                {
                    _db.ChecklistElementsTable.Remove(checklistElement);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Deleting Element Data", ex);
            }
        }

        public async Task<IList<ChecklistElementModel>> GetAllChecklistElementsAsync()
        {
            try
            {
                var checklistElements = await _db.ChecklistElementsTable.ToListAsync();
                return (checklistElements);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Checklist Elements", ex);
            }
        }

        public async Task<IList<ChecklistElementModel>> GetAllChecklistElementsByCategoryIdAsync(int categoryId)
        {
            try
            {
                var elementsList = await _db.ChecklistElementsTable.Where(c => c.CartegoryId == categoryId).ToListAsync();
                return elementsList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Checklist Elements from Database", ex);
            }
        }

        public async Task UpdateChecklistElement(ChecklistElementModel elementModel)
        {
            try
            {
                await GetSingleElementByIdAsync(elementModel.GuidId);
                //
                checklistElementModel.Name = elementModel.Name;
                checklistElementModel.CartegoryId = elementModel.CartegoryId;
                checklistElementModel.ElementRank = elementModel.ElementRank;
                checklistElementModel.Location = elementModel.Location;
                checklistElementModel.RoomNumber = elementModel.RoomNumber;
                checklistElementModel.PublicVisible = elementModel.PublicVisible;
                checklistElementModel.Description = elementModel.Description;
                checklistElementModel.VendorId = elementModel.VendorId;
                checklistElementModel.BrandName = elementModel.BrandName;
                checklistElementModel.Installed = elementModel.Installed;
                checklistElementModel.Replace = elementModel.Replace;

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Updating Checklist Element", ex);
            }
        }

        // Checklist Element Details Section

        //public async Task CreateNewChecklistElementDetailAsync(ChecklistElementDetailModel checklistElementDetail, int elementId)
        //{
        //    checklistElementDetail.ElementId = elementId;
        //    await _db.ChecklistElementDetailsTable.AddAsync(checklistElementDetail);
        //    await _db.SaveChangesAsync();
        //}

        public async Task CreateNewChecklistElementDetailAsync(ChecklistElementDetailModel checklistElementDetail, Guid elementGuid)
        {
            try
            {
                checklistElementDetail.GuidId = elementGuid;
                await _db.ChecklistElementDetailsTable.AddAsync(checklistElementDetail);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Creating New Checklist Element Detail", ex);
            }
        }

        //public async Task<ChecklistElementDetailModel> GetSingleElementDetailsByIdAsync(int elementId)
        //{
        //    //  var maxId = _db.ChecklistElementDetailsTable.Where(c => c.ElementId == elementId).Max(i => i.Id);

        //    checklistElementDetailModel = await _db.ChecklistElementDetailsTable.FirstOrDefaultAsync(c => c.FinalStatus == false);
        //    if (checklistElementDetailModel == null)
        //    {
        //        checklistElementDetailModel = await _db.ChecklistElementDetailsTable.OrderByDescending(c => c.Id).FirstOrDefaultAsync();
        //    }
        //    return (checklistElementDetailModel);
        //}

        public async Task<ChecklistElementDetailModel> GetSingleElementDetailsAsync()
        {
            try
            {
                checklistElementDetailModel = await _db.ChecklistElementDetailsTable.FirstOrDefaultAsync(c => c.FinalStatus == false);
                if (checklistElementDetailModel == null)
                {
                    checklistElementDetailModel = await _db.ChecklistElementDetailsTable.OrderByDescending(c => c.GuidId).FirstOrDefaultAsync();
                }
                return (checklistElementDetailModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Element Details from Database", ex);
            }
        }

        private async Task<ChecklistElementDetailModel> GetElementDetailsByIdAsync(Guid elementDetailsGuid)
        {
            try
            {
                checklistElementDetailModel = await _db.ChecklistElementDetailsTable.FirstOrDefaultAsync(c => c.GuidId == elementDetailsGuid);
                return (checklistElementDetailModel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Element details from Database", ex);
            }
        }

        public async Task<IList<ChecklistElementDetailModel>> GetAllChecklistElementDetailsAsync()
        {
            try
            {
                var checklistElementDetails = await _db.ChecklistElementDetailsTable.ToListAsync();
                return (checklistElementDetails);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting All Checklist Element Details from Database", ex);
            }
        }

        public async Task<List<ChecklistBuilderModel>> GetAllUnitCategoriesAndSubElementsAsync(int unitId)
        {
            try
            {
                List<ChecklistBuilderModel> checklistBuilderList = new List<ChecklistBuilderModel>();

                IList<ChecklistCategoryModel> categoriesList = await _db.ChecklistCategoriesTable.Where(u => u.UnitChecklistId == unitId).ToListAsync();

                foreach (var cate in categoriesList)
                {
                    var elements = _db.ChecklistElementsTable.Where(el => el.CartegoryId == cate.Id).ToList();

                    if (elements.Count > 0)
                    {
                        ChecklistBuilderModel checklistBuilder = new ChecklistBuilderModel();

                        checklistBuilder.CategoryId = cate.Id;
                        checklistBuilder.CategoryName = cate.Name;
                        checklistBuilder.checklistElementsList = elements;

                        checklistBuilderList.Add(checklistBuilder);
                    }

                }

                return checklistBuilderList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Fetching Data from Database", ex);
            }           
        }

        public async Task UpdateChecklistElementDatailsAsync(ChecklistElementDetailModel elementDetailsModel)
        {
            try
            {
                await GetElementDetailsByIdAsync(elementDetailsModel.GuidId);

                var nextMaint = elementDetailsModel.EndEventDate;
                if (nextMaint != null)
                {
                    nextMaint = nextMaint.Value.AddDays(7);
                }

                //
                checklistElementDetailModel.Status = elementDetailsModel.Status;
                //required
                checklistElementDetailModel.FaultType = elementDetailsModel.FaultType;
                //required
                checklistElementDetailModel.FaultOther = elementDetailsModel.FaultOther;
                checklistElementDetailModel.ActionType = elementDetailsModel.ActionType;
                checklistElementDetailModel.ActionOther = elementDetailsModel.ActionOther;
                //required
                checklistElementDetailModel.StartEventDate = elementDetailsModel.StartEventDate;
                checklistElementDetailModel.EndEventDate = elementDetailsModel.EndEventDate;
                //required
                checklistElementDetailModel.StartEventHour = elementDetailsModel.StartEventHour;
                checklistElementDetailModel.EndEventHour = elementDetailsModel.EndEventHour;
                checklistElementDetailModel.LastMINT = elementDetailsModel.EndEventDate;
                checklistElementDetailModel.NextMINT = nextMaint;
                //required
                checklistElementDetailModel.FaultDescription = elementDetailsModel.FaultDescription;
                checklistElementDetailModel.ResponseDescription = elementDetailsModel.ResponseDescription;
                checklistElementDetailModel.Note = " ";
                checklistElementDetailModel.EmployeesInvolved = elementDetailsModel.EmployeesInvolved;
                //required
                checklistElementDetailModel.PublicVisible = elementDetailsModel.PublicVisible;
                checklistElementDetailModel.FaultRank = "5";
                checklistElementDetailModel.FinalStatus = elementDetailsModel.FinalStatus;
                checklistElementDetailModel.ElementId = elementDetailsModel.ElementId;


                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Updating data in Database", ex);
            }
        }

        public async Task<Guid> CreateNewChecklistDetailsElementAsync(ChecklistElementDetailModel checklistElementDetails)
        {
            try
            {
                Guid guid = Guid.NewGuid();

                checklistElementDetails.GuidId = guid;

                await _db.ChecklistElementDetailsTable.AddAsync(checklistElementDetails);
                await _db.SaveChangesAsync();

                var newElementDetailId = checklistElementDetails.GuidId;

                return newElementDetailId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Data Insertion into Database", ex);
            }
        }




        //public async Task DeleteElementDetailsByIdAsync(int elementDetailsId)
        //{
        //    var checklistElementDetail = await _db.ChecklistElementDetailsTable.FindAsync(elementDetailsId);

        //    if (checklistElementDetail != null)
        //    {
        //        _db.ChecklistElementDetailsTable.Remove(checklistElementDetail);
        //        await _db.SaveChangesAsync();
        //    }
        //}

        public async Task DeleteElementDetailsByIdAsync(Guid elementDetailsGuid)
        {
            try
            {
                var checklistElementDetail = await _db.ChecklistElementDetailsTable.FindAsync(elementDetailsGuid);

                if (checklistElementDetail != null)
                {
                    _db.ChecklistElementDetailsTable.Remove(checklistElementDetail);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        // Unit Checklist

        public UnitChecklistModel unitChecklistModel { get; set; }



        public async Task AddUnitChecklist(int unitId)
        {
            try
            {
                unitChecklistModel.UnitID = unitId;
                unitChecklistModel.PublicVisible = false;
                unitChecklistModel.Description = "";
                unitChecklistModel.GeneralStatus = "Ideal";
                unitChecklistModel.LastUpdate = DateTime.Now;
                unitChecklistModel.UnitID = 0;

                await _db.UnitChecklistTable.AddAsync(unitChecklistModel);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Adding Unit Checklist", ex);
            }
        }

        public Task DeleteUnitChecklist(int unitId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUnitChecklist(int unitId)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfChecklistExistByUnitId(int unitId)
        {
            try
            {
                bool exist = false;

                var checklist = _db.UnitChecklistTable.FirstOrDefault(u => u.UnitID == unitId);

                if (checklist != null)
                {
                    exist = true;
                }

                return exist;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Getting Checklist Status", ex);
            }
        }

    }
}
