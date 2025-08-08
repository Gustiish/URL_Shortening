using URL_Shortening.Models;

namespace URL_Shortening.Services
{
    public interface IUrlBuilder
    {
        public IUrlBuilder SetOriginalUrl(UrlDTO url); // Input från klient.
        public IUrlBuilder SetShortUrl(); //Metod för att generara random string
        ShortURL Build();
    }
}
