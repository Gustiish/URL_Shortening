using URL_Shortening.Database;
using URL_Shortening.Models;
using URL_Shortening.Services.Interfaces;

namespace URL_Shortening.Services.Classes
{
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _context;
        public DataService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ResponseShortUrlDto ConvertModelToDTO(ShortURL shortUrl)
        {
            ResponseShortUrlDto shortUrlDTO = new ResponseShortUrlDto()
            {
                Id = shortUrl.Id,
                OriginalUrl = shortUrl.OriginalUrl,
                ShortUrl = shortUrl.ShortUrl,
                CreatedAt = shortUrl.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                UpdatedAt = shortUrl.UpdatedAt?.ToString("yyyy-MM-dd HH:mm"),
                AccessCount = shortUrl.AccessCount
            };

            return shortUrlDTO;

        }


        public async Task UpdateAccessCountAsync(ShortURL url)
        {
            url.AccessCount++;
            _context.Update(url);
            await _context.SaveChangesAsync();

        }
    }
}
