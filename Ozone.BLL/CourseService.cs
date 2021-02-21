using Ozone.DAL.Repositories;
using Ozone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.BLL
{
    public interface ICourseService
    {
        Task<Course> GetCourseById(int id);
        Task<List<Course>> GetCourses();
        Task<bool> Insert(Course course);
        Task<bool> Remove(Course course);
        Task<bool> Update(Course course);
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Insert(Course course)
        {
            try
            {
                var status = await _repository.Add(course);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Update(Course course)
        {
            try
            {
                var status = await _repository.Update(course);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Remove(Course course)
        {
            try
            {
                var status = await _repository.Remove(course);
                return status;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<Course>> GetCourses()
        {
            try
            {
                var items = await _repository.GetCourses();
                return items;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }

        public async Task<Course> GetCourseById(int id)
        {
            try
            {
                var item = await _repository.GetCourseById(id);
                return item;

            }
            catch (OzoneException ex)
            {
                throw new OzoneException(ex.Message, ex.InnerException);
            }
        }
    }
}
