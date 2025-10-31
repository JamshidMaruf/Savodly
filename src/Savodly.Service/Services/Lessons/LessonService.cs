using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Savodly.DataAccess.UnitOfWorks;
using Savodly.Domain.Entities;
using Savodly.Service.Exceptions;
using Savodly.Service.Services.Files;
using Savodly.Service.Services.Lessons.Models;

namespace Savodly.Service.Services.Lessons;

public class LessonService(IUnitOfWork unitOfWork,IFileService fileService) : ILessonService
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
         return await unitOfWork.Lessons
            .SelectAllAsQueryable()
            .Where(l => l.ModuleId == moduleId)
            .Select(l => new LessonViewModel
            {
                Name = l.Name
            })
            .ToListAsync();
    }

    public async Task UploadFileAsync(int lessonId, IFormFile file)
    {
        _ = await unitOfWork.Lessons.SelectAsync(l => l.Id == lessonId)
            ?? throw new NotFoundException($"No lesson was found with ID {lessonId}");

        string inputFileExtension = Path.GetExtension(file.FileName);
        string[] acceptableExtensions = new[] { ".jpg", ".png", ".docx", ".pdf", ".sql", ".txt", ".csv" };
        
        if (acceptableExtensions.Contains(inputFileExtension))
            throw new ArgumentIsNotValidException($"{inputFileExtension} inputFileExtension is not accepted");

        var result = await fileService.UploadAsync(file, "Files/Files");

        unitOfWork.LessonFiles.Insert(new LessonFile
        {
            FileName = result.FileName,
            FilePath = result.FilePath,
            LessonId = lessonId
        });

        await unitOfWork.SaveAsync();
    }

    public async Task UploadVideoAsync(int lessonId, IFormFile video)
    {
        _ = await unitOfWork.Lessons.SelectAsync(l => l.Id == lessonId)
            ?? throw new NotFoundException($"No lesson was found with ID = {lessonId}");

        string inputFileExtension = Path.GetExtension(video.FileName);
        string[] acceptableExtensions = new[] { ".mp4", ".avi", ".mkv", ".mov", ".flv" };

        if (acceptableExtensions.Contains(inputFileExtension))
            throw new ArgumentIsNotValidException($"{inputFileExtension} extension is not accepted");

        var result = await fileService.UploadAsync(video, "Files/Videos");

        unitOfWork.LessonVideos.Insert(new LessonVideo
        {
            FileName = result.FileName,
            FilePath = result.FilePath,
            LessonId = lessonId
        });

        await unitOfWork.SaveAsync();
    }

    public async Task AddDocumentationAsync(int lessonId, string text)
    {
        _ = await unitOfWork.Lessons.SelectAsync(l => l.Id == lessonId)
            ?? throw new NotFoundException($"No lesson was found with ID = {lessonId}");

        unitOfWork.LessonDocumentations.Insert(new LessonDocumentation
        {
            Text = text,
            LessonId = lessonId
        });

        await unitOfWork.SaveAsync();
    }
}
