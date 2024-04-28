using Domain.Entities;
using Domain.IRepository;
using Services_Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> CreateCourseAsync(string courseName)
        {
            var courseEntity = new Course()
            {
                Title = courseName
            };

            return await _courseRepository.AddAsync(courseEntity);
        }

        public async Task<Course> UpdateCourseAsync(int id, string courseName)
        {
            var courseEntity = await _courseRepository.GetByIdAsync(id);

            if (courseEntity == null)
            {
                return null;
            }

            courseEntity.Title = courseName;
            await _courseRepository.UpdateAsync(courseEntity);

            return courseEntity;
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course != null)
            {
                await _courseRepository.DeleteAsync(course);
            }
        }
    }
}
