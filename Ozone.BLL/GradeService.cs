using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface IGradeService
    {
        Task<Grade> GetGradeById(int id);
        Task<List<Grade>> GetGrades();
        Task<bool> Insert(Grade grade);
        Task<bool> Remove(Grade grade);
        Task<bool> Update(Grade grade);
    }

    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _repository;

        public GradeService(IGradeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Insert(Grade grade)
        {
            try
            {
                var status = await _repository.Add(grade);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Update(Grade grade)
        {
            try
            {
                var status = await _repository.Update(grade);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Remove(Grade grade)
        {
            try
            {
                var status = await _repository.Remove(grade);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<Grade>> GetGrades()
        {
            try
            {
                var items = await _repository.GetGrades();
                return items;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<Grade> GetGradeById(int id)
        {
            try
            {
                var item = await _repository.GetGradeById(id);
                return item;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
    }
}
