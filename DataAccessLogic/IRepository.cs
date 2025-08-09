using URL_Shortening.Models;

namespace URL_Shortening.DataAccessLogic
{

    public interface IRepository
    {
        Task<ShortURL?> GetAsync(int id);
        Task<bool> CreateAsync(ShortURL shortURL);
        Task UpdateAsync(ShortURL shortURL);
        Task DeleteAsync(int id);
        Task<ShortURL?> GetByShortUrlAsync(string url);
    }
}
