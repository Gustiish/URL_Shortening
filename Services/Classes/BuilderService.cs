using System.Text;
using URL_Shortening.Database;
using URL_Shortening.Services.Interfaces;

namespace URL_Shortening.Services.Classes
{
    public class BuilderService : IBuilderService
    {
        private readonly ApplicationDbContext _context;
        public BuilderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CheckShortUrl(string url)
        {
            return _context.ShortURLs.Any(x => x.ShortUrl == url);
        }

        public string GenerateShortUrl()
        {
            Random random = new();
            const string poolLetters = "abcdefghijklmnopqrstuvwxyz";
            const string poolNumbers = "0123456789";
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                char c = poolLetters[random.Next(0, poolLetters.Length)];
                builder.Append(c);
            }

            for (int i = 0; i < 3; i++)
            {
                char c = poolNumbers[random.Next(0, poolNumbers.Length)];
                builder.Append(c);
            }

            if (CheckShortUrl(builder.ToString()))
                return GenerateShortUrl();

            return builder.ToString();
        }

    }
}
