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
        Task UpdateAsync(int id, StudentUpdateModel model);
        Task DeleteAsync(int id);
        Task<StudentViewModel> GetByIdAsync(int id);
        Task<List<StudentViewModel>> GetAllAsync(string search);
        Task<List<StudentViewModel>> GetAllByTeacherIdAsync(int teacherId);
        Task<List<StudentViewModel>> GetAllByCourseIdAsync(int courseId);
    }
}
