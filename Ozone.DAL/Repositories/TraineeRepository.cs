using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface ITraineeRepository
    {
        Task<bool> Add(object entity);
        Task<Trainee> GetTraineeById(int id);
        Task<List<Trainee>> GetTrainees();
        Task<bool> Remove(object entity);
        Task<bool> SaveChanges();
        Task<bool> Update(object entity);
    }

    public class TraineeRepository : ITraineeRepository
    {
        private readonly ApplicationDbContext _db;

        public TraineeRepository(ApplicationDbContext db)
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


        public async Task<List<Trainee>> GetTrainees()
        {
            try
            {
                var items = await _db.Trainees.ToListAsync();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Trainees from Database", ex);
            }
        }

        public async Task<Trainee> GetTraineeById(int id)
        {
            try
            {
                var item = await _db.Trainees.FirstOrDefaultAsync(x => x.TraineeId == id);
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Single Trainee from Database", ex);
            }
        }
    }
}
