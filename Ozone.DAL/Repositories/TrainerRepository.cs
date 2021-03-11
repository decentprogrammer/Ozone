using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface ITrainerRepository
    {
        Task<bool> Add(object entity);
        Task<Trainer> GetTrainerById(int id, bool includeDetails = false);
        Task<List<Trainer>> GetTrainers(bool includeDetails = false);
        Task<bool> Remove(object entity);
        Task<bool> SaveChanges();
        Task<bool> Update(object entity);
    }

    public class TrainerRepository : ITrainerRepository
    {
        private readonly ApplicationDbContext _db;

        public TrainerRepository(ApplicationDbContext db)
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


        public async Task<List<Trainer>> GetTrainers(bool includeDetails = false)
        {
            try
            {
                List<Trainer> items = null;

                if (includeDetails)
                {
                    items = await _db.Trainers
                                     .Include(p => p.TrainerTrainings)
                                     .ToListAsync();
                    return items;
                }

                items = await _db.Trainers.ToListAsync();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Trainers from Database", ex);
            }
        }

        public async Task<Trainer> GetTrainerById(int id, bool includeDetails = false)
        {
            try
            {
                Trainer item = null;
                if (includeDetails)
                {
                    item = await _db.Trainers.Include(p => p.TrainerTrainings).FirstOrDefaultAsync(x => x.TrainerId == id);
                    return item;
                }

                item = await _db.Trainers.FirstOrDefaultAsync(x => x.TrainerId == id);
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Single Trainer from Database", ex);
            }
        }
    }
}
