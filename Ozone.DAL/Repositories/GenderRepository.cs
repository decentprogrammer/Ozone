using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface IGenderRepository
    {
        Task<bool> Add(object entity);
        Task<Gender> GetGenderById(int id);
        Task<List<Gender>> GetGenders();
        Task<bool> Remove(object entity);
        Task<bool> SaveChanges();
        Task<bool> Update(object entity);
    }

    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDbContext _db;

        public GenderRepository(ApplicationDbContext db)
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


        public async Task<List<Gender>> GetGenders()
        {
            try
            {
                var items = await _db.Gender.ToListAsync();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Genders from Database", ex);
            }
        }

        public async Task<Gender> GetGenderById(int id)
        {
            try
            {
                var item = await _db.Gender.FirstOrDefaultAsync(x => x.GenderId == id);
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Single Gender from Database", ex);
            }
        }
    }
}
