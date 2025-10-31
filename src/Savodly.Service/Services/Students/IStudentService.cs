using Savodly.Service.Students.Models;

namespace Savodly.Service.Students;

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
