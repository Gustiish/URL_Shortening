using URL_Shortening.Models;

namespace URL_Shortening.Services.Interfaces
{
    public interface IBuilder
    {
        public IBuilder SetOriginalUrl(CreateShortUrlDto url); // Input från klient.
        public IBuilder SetShortUrl(); //Metod för att generara random string
        public IBuilder SetCreatedAt();
        ShortURL Build();
    }
}
