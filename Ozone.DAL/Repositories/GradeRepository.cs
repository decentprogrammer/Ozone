using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface IGradeRepository
    {
        Task<bool> Add(object entity);
        Task<Grade> GetGradeById(int id);
        Task<List<Grade>> GetGrades();
        Task<bool> Remove(object entity);
        Task<bool> SaveChanges();
        Task<bool> Update(object entity);
    }

    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _db;

        public GradeRepository(ApplicationDbContext db)
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


        public async Task<List<Grade>> GetGrades()
        {
            try
            {
                var items = await _db.Grades.ToListAsync();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Grades from Database", ex);
            }
        }

        public async Task<Grade> GetGradeById(int id)
        {
            try
            {
                var item = await _db.Grades.FirstOrDefaultAsync(x => x.GradeId == id);
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Single Grade from Database", ex);
            }
        }
    }
}
