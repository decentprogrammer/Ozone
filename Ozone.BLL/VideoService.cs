using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface IVideoService
    {
        Task<Video> GetVideoById(int id, bool includeDetails = false);
        Task<List<Video>> GetVideos(bool includeDetails = false);
        Task<bool> Insert(Video video);
        Task<bool> Remove(Video video);
        Task<bool> Update(Video video);
    }

    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _repository;

        public VideoService(IVideoRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Insert(Video video)
        {
            try
            {
                var status = await _repository.Add(video);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
        public async Task<bool> Update(Video video)
        {
            try
            {
                var status = await _repository.Update(video);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
        public async Task<bool> Remove(Video video)
        {
            try
            {
                var status = await _repository.Remove(video);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
        public async Task<List<Video>> GetVideos(bool includeDetails = false)
        {
            try
            {
                var items = await _repository.GetVideos(includeDetails);
                return items;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
        public async Task<Video> GetVideoById(int id, bool includeDetails = false)
        {
            try
            {
                var item = await _repository.GetVideoById(id, includeDetails);
                return item;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
    }
}
