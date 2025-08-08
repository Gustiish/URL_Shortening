using Microsoft.AspNetCore.Mvc;
using URL_Shortening.DataAccessLogic;
using URL_Shortening.Models;
using URL_Shortening.Services;

namespace URL_Shortening.Controllers
{
    [ApiController]
    [Route("api/shorten")]
    public class Shorten : ControllerBase
    {
        private readonly IUrlBuilder _builder;
        private readonly IRepository _repository;
        public Shorten(IUrlBuilder builder, IRepository repository)
        {
            _builder = builder;
            _repository = repository;
        }


        [HttpPost]
        public IActionResult Create(UrlDTO Url)
        {
            ShortURL shortUrl = _builder.SetOriginalUrl(Url).SetShortUrl().Build();
            if (_repository.Create(shortUrl))
                return Created($"{Url.Url}", shortUrl);
            return BadRequest();
        }



    }
}
