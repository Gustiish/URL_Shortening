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

        public bool Create(ShortURL shortURL)
        {
            try
            {
                _context.ShortURLs.Add(shortURL);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.ShortURLs.Remove(Get(id));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public ShortURL? Get(int Id)
        {
            try
            {
                return _context.ShortURLs.FirstOrDefault(x => x.Id == Id) ?? null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }

        public void Update(ShortURL shortURL)
        {
            try
            {
                _context.ShortURLs.Update(shortURL);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}
