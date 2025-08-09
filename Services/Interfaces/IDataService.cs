using URL_Shortening.Models;

namespace URL_Shortening.Services.Interfaces
{
    public interface IDataService
    {
        Task UpdateAccessCountAsync(ShortURL url);
        ResponseShortUrlDto ConvertModelToDTO(ShortURL url);
    }
}
