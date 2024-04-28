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
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepository<Enrollment> _enrollmentRepository;

        public EnrollmentService(IRepository<Enrollment> enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            return await _enrollmentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _enrollmentRepository.GetAllAsync();
        }

        public async Task<Enrollment> CreateEnrollmentAsync(int studentId, int courseId)
        {
            var enrollmentEntity = new Enrollment()
            {
                StudentId = studentId,
                CourseId = courseId
            };

            return await _enrollmentRepository.AddAsync(enrollmentEntity);
        }

        public async Task DeleteEnrollmentAsync(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);

            if (enrollment != null)
            {
                await _enrollmentRepository.DeleteAsync(enrollment);
            }
        }
    }
}
