using URL_Shortening.Models;

namespace URL_Shortening.Services
{
    public class UrlBuilder : IUrlBuilder
    {
        private ShortURL _shortUrl = new ShortURL();
        private readonly IShortUrlService _service;
        public UrlBuilder(IShortUrlService service)
        {
            _service = service;
        }

        public IUrlBuilder SetOriginalUrl(UrlDTO url)
        {
            _shortUrl.OriginalUrl = url.Url;
            return this;
        }

        public IUrlBuilder SetShortUrl()
        {
            _shortUrl.ShortUrl = _service.GenerateShortUrl();
            return this;
        }

        public ShortURL Build() => _shortUrl;




    }
}
