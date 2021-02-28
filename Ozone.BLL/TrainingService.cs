using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface ITrainingService
    {
        Task<Training> GetTrainingById(int id, bool includeDetails = false);
        Task<List<Training>> GetTrainings(bool includeDetails = false);
        Task<bool> Insert(Training training);
        Task<bool> Remove(Training training);
        Task<bool> Update(Training training);
    }

    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _repository;

        public TrainingService(ITrainingRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Insert(Training training)
        {
            try
            {
                var status = await _repository.Add(training);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Update(Training training)
        {
            try
            {
                var status = await _repository.Update(training);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Remove(Training training)
        {
            try
            {
                var status = await _repository.Remove(training);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<Training>> GetTrainings(bool includeDetails = false)
        {
            try
            {
                var items = await _repository.GetTrainings(includeDetails);
                return items;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<Training> GetTrainingById(int id, bool includeDetails = false)
        {
            try
            {
                var item = await _repository.GetTrainingById(id, includeDetails);
                return item;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
    }
}
