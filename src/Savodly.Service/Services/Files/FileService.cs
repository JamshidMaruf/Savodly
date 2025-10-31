using Microsoft.AspNetCore.Http;
using Savodly.Service.Exceptions;
using Savodly.Service.Helpers;

namespace Savodly.Service.Services.Files;

public class FileService : IFileService
{
    public async Task<(string FileName, string FilePath)> UploadAsync(IFormFile file, string folder)
    {
        if(file == null || file.Length <= 0)
            throw new ArgumentIsNotValidException("file cannot be empty");

        var directory = Path.Combine(EnviromentHelper.WebRootPath, folder);
        
        if (Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        string filePath = Path.Combine(directory, fileName);
        
        await using var steam = new FileStream(filePath, FileMode.OpenOrCreate);
        await file.CopyToAsync(steam);

        return (fileName, filePath);
    }
}
