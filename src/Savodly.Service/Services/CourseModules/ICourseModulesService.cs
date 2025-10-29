using Savodly.Service.Services.CourseModules.Models;

namespace Savodly.Service.Services.CourseModules;
public interface ICourseModulesServcie
{
    Task CreateAsync(ModuleCreateModel model);
    Task UpdateAsync(int id, ModuleUpdateModel model);
    Task DeleteAsync(int id);
    Task<ModuleViewModel> GetByIdAsync(int id);
    Task<List<ModuleViewModel>> GetAllByCourseIdAsync(int courseId);
}