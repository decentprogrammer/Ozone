using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface IGenderService
    {
        Task<Gender> GetGenderById(int id);
        Task<List<Gender>> GetGenders();
        Task<bool> Insert(Gender gender);
        Task<bool> Remove(Gender gender);
        Task<bool> Update(Gender gender);
    }

    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _repository;

        public GenderService(IGenderRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Insert(Gender gender)
        {
            try
            {
                var status = await _repository.Add(gender);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Update(Gender gender)
        {
            try
            {
                var status = await _repository.Update(gender);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Remove(Gender gender)
        {
            try
            {
                var status = await _repository.Remove(gender);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<Gender>> GetGenders()
        {
            try
            {
                var items = await _repository.GetGenders();
                return items;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<Gender> GetGenderById(int id)
        {
            try
            {
                var item = await _repository.GetGenderById(id);
                return item;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
    }
}
