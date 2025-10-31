using Microsoft.AspNetCore.Http;
using Savodly.Service.Services.Lessons.Models;

namespace Savodly.Service.Services.Lessons;
public interface ILessonService
{
    Task Create(LessonCreateModel model);
    Task Update(int id, LessonUpdateModel model);
    Task Delete(int id);
    Task<LessonViewModel> GetAsync(int id);
    Task<List<LessonViewModel>> GetAllByModuleId(int moduleId);
    Task UploadFileAsync(int lessonId, IFormFile file);
    Task UploadVideoAsync(int lessonId, IFormFile video);
    Task AddDocumentationAsync(int lessonId, string text);
}
