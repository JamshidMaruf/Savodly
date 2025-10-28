using Savodly.Service.Services.Settings.Models;

namespace Savodly.Service.Services.Settings;
public interface ISettingService
{
    Task CreateAsync(SettingCreateModel model);
    Task DeleteAsync(string key);
    Task<SettingViewModel> GetAsync(string key);
    Task<Dictionary<string, string>> GetByCategoryAsync(string category);
}
