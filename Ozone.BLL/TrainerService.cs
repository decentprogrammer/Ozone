using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface ITrainerService
    {
        Task<Trainer> GetTrainerById(int id, bool includeDetails = false);
        Task<List<Trainer>> GetTrainers(bool includeDetails = false);
        Task<bool> Insert(Trainer trainer);
        Task<bool> Remove(Trainer trainer);
        Task<bool> Update(Trainer trainer);
    }

    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _repository;

        public TrainerService(ITrainerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Insert(Trainer trainer)
        {
            try
            {
                var status = await _repository.Add(trainer);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
        public async Task<bool> Update(Trainer trainer)
        {
            try
            {
                var status = await _repository.Update(trainer);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
        public async Task<bool> Remove(Trainer trainer)
        {
            try
            {
                var status = await _repository.Remove(trainer);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
        public async Task<List<Trainer>> GetTrainers(bool includeDetails = false)
        {
            try
            {
                var items = await _repository.GetTrainers(includeDetails);
                return items;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
        public async Task<Trainer> GetTrainerById(int id, bool includeDetails = false)
        {
            try
            {
                var item = await _repository.GetTrainerById(id, includeDetails);
                return item;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
    }
}
