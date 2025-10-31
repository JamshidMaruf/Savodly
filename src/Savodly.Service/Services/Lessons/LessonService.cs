using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Savodly.DataAccess.UnitOfWorks;
using Savodly.Domain.Entities;
using Savodly.Service.Exceptions;
using Savodly.Service.Services.Lessons.Models;

namespace Savodly.Service.Services.Lessons;

public class LessonService(IUnitOfWork unitOfWork) : ILessonService
{
    public async Task Create(LessonCreateModel model)
    {
        _ = await unitOfWork.Modules.SelectAsync(m => m.Id == model.ModuleId)
            ?? throw new NotFoundException($"Module was not found with ID = {model.ModuleId}");

        unitOfWork.Lessons.Insert(new Lesson
        {
            CourseId = model.CourseId,
            Name = model.Name,
            ModuleId = model.ModuleId
        });

        await unitOfWork.SaveAsync();
    }

    public async Task Update(int id, LessonUpdateModel model)
    {
        var lessonForUpdation = await unitOfWork.Lessons.SelectAsync(l => l.Id == id)
            ?? throw new NotFoundException($"Lesson was not found with ID = {id}");

        lessonForUpdation.Name = model.Name;

        await unitOfWork.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var lessonForDeletion = await unitOfWork.Lessons
            .SelectAsync(
            predicate: l => l.Id == id, 
            include: new[] { "LessonVideos", "LessonFiles", "Documentation" })
                ?? throw new NotFoundException($"No lesson was found with ID = {id}");

        unitOfWork.Lessons.Delete(lessonForDeletion);

        foreach(var lessonFile in lessonForDeletion.LessonFiles)
            unitOfWork.LessonFiles.Delete(lessonFile);
        
        foreach(var lessonVideo in lessonForDeletion.LessonVideos)
            unitOfWork.LessonVideos.Delete(lessonVideo);
        
        if(lessonForDeletion.Documentation != null)
        unitOfWork.LessonDocumentations.Delete(lessonForDeletion.Documentation);

        await unitOfWork.SaveAsync();
    }

    // lesson qanaqa tartibda get qilinishini bilmaganim uchun faqat name ni get qildim
    public async Task<LessonViewModel> GetAsync(int id)
    {
        var lesson =  await unitOfWork.Lessons.SelectAsync(l => l.Id == id)
            ?? throw new NotFoundException($"No lesson was found with ID = {id}");

        return new LessonViewModel
        {
            Name = lesson.Name
        };
    }

    public async Task<List<LessonViewModel>> GetAllByModuleId(int moduleId)
    {
        var lessons = await unitOfWork.Lessons
            .SelectAllAsQueryable()
            .Where(l => l.ModuleId == moduleId)
            .ToListAsync();

        return 
    }

    public Task UploadFileAsync(int lessonId, IFormFile file)
    {
        throw new NotImplementedException();
    }

    public Task UploadVideoAsync(int lessonId, IFormFile video)
    {
        throw new NotImplementedException();
    }

    public Task AddDocumentationAsync(int lessonId, string text)
    {
        throw new NotImplementedException();
    }
}
