using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface ITrainingRepository
    {
        Task<bool> Add(object entity);
        Task<Training> GetTrainingById(int id, bool includeDetails = false);
        Task<List<Training>> GetTrainings(bool includeDetails = false);
        Task<bool> Remove(object entity);
        Task<bool> SaveChanges();
        Task<bool> Update(object entity);
    }

    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _db;

        public TrainingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Add(object entity)
        {
            try
            {
                _db.Add(entity);
                return await SaveChanges();
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Adding Data to Database", ex);
            }
        }

        public async Task<bool> Remove(object entity)
        {
            try
            {
                _db.Remove(entity);
                return await SaveChanges();
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Removing Data from Database", ex);
            }
        }

        public async Task<bool> Update(object entity)
        {
            try
            {
                _db.Update(entity);
                return await SaveChanges();
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Updating Database Data", ex);
            }
        }

        public async Task<bool> SaveChanges()
        {
            return await _db.SaveChangesAsync() > 0;
        }


        public async Task<List<Training>> GetTrainings(bool includeDetails = false)
        {
            try
            {

                List<Training> items = null;

                if (includeDetails)
                {
                    items = await _db.Trainings
                                     .Include(p => p.Course)
                                     .Where(x => x.IsDeleted == 0)
                                     .ToListAsync();
                    return items;
                }

                items = await _db.Trainings.Where(x => x.IsDeleted == 0).ToListAsync();
                return items;


            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Trainings from Database", ex);
            }
        }

        public async Task<Training> GetTrainingById(int id, bool includeDetails = false)
        {
            try
            {
                Training item = null;

                if (includeDetails)
                {
                    item = await _db.Trainings
                                    .Include(p => p.Course)
                                    .FirstOrDefaultAsync(x => x.TrainingId == id);
                    return item;
                }


                item = await _db.Trainings.FirstOrDefaultAsync(x => x.TrainingId == id);
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Single Training from Database", ex);
            }
        }
    }
}
