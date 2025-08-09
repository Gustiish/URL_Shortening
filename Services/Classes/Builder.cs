using URL_Shortening.Models;
using URL_Shortening.Services.Interfaces;

namespace URL_Shortening.Services.Classes
{
    public class Builder : IBuilder
    {
        private readonly ShortURL _shortUrl = new ShortURL();
        private readonly IBuilderService _service;
        public Builder(IBuilderService service)
        {
            _service = service;
        }

        public IBuilder SetOriginalUrl(CreateShortUrlDto url)
        {
            _shortUrl.OriginalUrl = url.Url;
            return this;
        }

        public IBuilder SetShortUrl()
        {
            _shortUrl.ShortUrl = _service.GenerateShortUrl();
            return this;
        }
        public IBuilder SetCreatedAt()
        {
            _shortUrl.CreatedAt = DateTime.Now;
            return this;
        }

        public ShortURL Build() => _shortUrl;


    }
}
