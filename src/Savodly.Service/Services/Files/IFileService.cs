using Microsoft.AspNetCore.Http;

namespace Savodly.Service.Services.Files;

public interface IFileService
{
    Task<(string FileName, string FilePath)> UploadAsync(IFormFile file, string folder);
}
