using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Abstraction
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> CreateStudentAsync(string studentName);
        Task<Student> UpdateStudentAsync(int id, string studentName);
        Task DeleteStudentAsync(int id);
    }
}
