using Microsoft.EntityFrameworkCore;
using URL_Shortening.Database;
using URL_Shortening.Models;

namespace URL_Shortening.DataAccessLogic
{

    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(ShortURL shortURL)
        {
            try
            {
                await _context.ShortURLs.AddAsync(shortURL);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetAsync(id);
                if (entity != null)
                {
                    _context.ShortURLs.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public async Task<ShortURL?> GetAsync(int id)
        {
            try
            {
                return await _context.ShortURLs.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public async Task UpdateAsync(ShortURL shortURL)
        {
            try
            {
                _context.ShortURLs.Update(shortURL);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public async Task<ShortURL?> GetByShortUrlAsync(string url)
        {
            try
            {
                return await _context.ShortURLs.FirstOrDefaultAsync(x => x.ShortUrl == url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

    }
}