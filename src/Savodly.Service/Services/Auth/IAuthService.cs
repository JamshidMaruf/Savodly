using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Savodly.Service.Services.Auth;
public interface IAuthService
{
    Task<string> GenerateToken(string id, EntityType type);
}
