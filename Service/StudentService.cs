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
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> CreateStudentAsync(string studentName)
        {
            var studentEntity = new Student()
            {
                Name = studentName
            };

            return await _studentRepository.AddAsync(studentEntity);
        }

        public async Task<Student> UpdateStudentAsync(int id, string studentName)
        {
            var studentEntity = await _studentRepository.GetByIdAsync(id);

            if (studentEntity == null)
            {
                return null;
            }

            studentEntity.Name = studentName;
            await _studentRepository.UpdateAsync(studentEntity);

            return studentEntity;
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student != null)
            {
                await _studentRepository.DeleteAsync(student);
            }
        }
    }
}
