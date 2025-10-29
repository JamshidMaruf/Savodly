using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savodly.Service.Student.Models;

namespace Savodly.Service.Student
{
    public interface IStudentService
    {
        Task CreateAsync(StudentCreateModel model);
        Task UpdateAsync(StudentUpdateModel model);
        Task DeleteAsync(int id);
        Task<StudentViewModel> GetAsync(int id);
        Task<List<StudentViewModel>> GetAllAsync();
        Task<List<StudentViewModel>> GetByTeacherIdAsync(int teacherId);
        Task<List<StudentViewModel>> GetByCourseIdAsync(int courseId);
        Task<bool> PhoneNumberExistsAsync(string phoneNumber);
    }
}
