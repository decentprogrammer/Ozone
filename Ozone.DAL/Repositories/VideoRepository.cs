using Microsoft.EntityFrameworkCore;
using Ozone.DAL;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.DAL.Repositories
{
    public interface IVideoRepository
    {
        Task<bool> Add(object entity);
        Task<Video> GetVideoById(int id, bool includeDetails = false);
        Task<List<Video>> GetVideos(bool includeDetails = false);
        Task<bool> Remove(object entity);
        Task<bool> SaveChanges();
        Task<bool> Update(object entity);
    }

    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationDbContext _db;

        public VideoRepository(ApplicationDbContext db)
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


        public async Task<List<Video>> GetVideos(bool includeDetails = false)
        {
            try
            {
                List<Video> items = null;

                if (includeDetails)
                {
                    items = await _db.Videos
                                     .Include(p => p.Course)
                                     .ToListAsync();
                    return items;
                }

                items = await _db.Videos.ToListAsync();
                return items;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Videos from Database", ex);
            }
        }

        public async Task<Video> GetVideoById(int id, bool includeDetails = false)
        {
            try
            {
                Video item = null;
                if (includeDetails)
                {
                    item = await _db.Videos.Include(p => p.Course).FirstOrDefaultAsync(x => x.VideoId == id);
                    return item;
                }

                item = await _db.Videos.FirstOrDefaultAsync(x => x.VideoId == id);
                return item;
            }
            catch (OzoneException ex)
            {
                throw new OzoneException("Error in Getting Single Video from Database", ex);
            }
        }
    }
}
