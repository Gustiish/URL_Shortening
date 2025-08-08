using Microsoft.EntityFrameworkCore;
using URL_Shortening.Models;
namespace URL_Shortening.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ShortURL> ShortURLs { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


    }
}
