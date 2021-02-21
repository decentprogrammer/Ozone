using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface ITraineeService
    {
        Task<Trainee> GetTraineeById(int id);
        Task<List<Trainee>> GetTrainees();
        Task<bool> Insert(Trainee trainee);
        Task<bool> Remove(Trainee trainee);
        Task<bool> Update(Trainee trainee);
    }

    public class TraineeService : ITraineeService
    {
        private readonly ITraineeRepository _repository;

        public TraineeService(ITraineeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Insert(Trainee trainee)
        {
            try
            {
                var status = await _repository.Add(trainee);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Update(Trainee trainee)
        {
            try
            {
                var status = await _repository.Update(trainee);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Remove(Trainee trainee)
        {
            try
            {
                var status = await _repository.Remove(trainee);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<Trainee>> GetTrainees()
        {
            try
            {
                var items = await _repository.GetTrainees();
                return items;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<Trainee> GetTraineeById(int id)
        {
            try
            {
                var item = await _repository.GetTraineeById(id);
                return item;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
    }
}
