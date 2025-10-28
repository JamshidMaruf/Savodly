using Savodly.Service.Services.Teachers.Models;

namespace Savodly.Service.Services.Teachers;
public interface ITeacherService
{
    Task CreateAsync(TeacherCreateModel model);
    Task UpdateAsync(int id, TeacherUpdateModel model);
    Task DeleteAsync(int id);
    Task<TeacherViewModel> GetByIdAsync(int id);
    Task<List<TeacherViewModel>> GetAllAsync(string search);
}