using Microsoft.AspNetCore.Mvc;
using URL_Shortening.DataAccessLogic;
using URL_Shortening.Models;
using URL_Shortening.Services.Interfaces;

namespace URL_Shortening.Controllers
{
    [ApiController]
    [Route("api/shorten")]
    public class Shorten : ControllerBase
    {
        private readonly IBuilder _builder;
        private readonly IRepository _repository;
        private readonly IDataService _service;
        public Shorten(IBuilder builder, IRepository repository, IDataService shortUrlService)
        {
            _builder = builder;
            _repository = repository;
            _service = shortUrlService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateShortUrlDto Url)
        {
            ShortURL shortUrl = _builder.SetOriginalUrl(Url).SetShortUrl().SetCreatedAt().Build();
            if (!await _repository.CreateAsync(shortUrl))
                return BadRequest();
            return Created($"{Url.Url}", _service.ConvertModelToDTO(shortUrl));
        }

        [HttpGet]
        [Route("{shortUrl}/stats")]
        public async Task<IActionResult> Get(string shortUrl)
        {
            ShortURL? url = await _repository.GetByShortUrlAsync(shortUrl) ?? null;

            if (url == null)
                return NotFound();
            await _service.UpdateAccessCountAsync(url);

            return Ok(_service.ConvertModelToDTO(url));
        }

        [HttpPut]
        [Route("{shortUrl}")]
        public async Task<IActionResult> Put(string shortUrl, [FromBody] CreateShortUrlDto url)
        {
            ShortURL? originalShort = await _repository.GetByShortUrlAsync(shortUrl) ?? null;
            if (originalShort == null)
                return NotFound();
            originalShort.OriginalUrl = url.Url;
            await _repository.UpdateAsync(originalShort);
            await _service.UpdateAccessCountAsync(originalShort);
            return Ok(_service.ConvertModelToDTO(originalShort));
        }

        [HttpDelete]
        [Route("{shortUrl}")]
        public async Task<IActionResult> Delete(string shortUrl)
        {
            ShortURL? originalShort = await _repository.GetByShortUrlAsync(shortUrl) ?? null;
            if (originalShort == null)
                return NotFound();
            await _repository.DeleteAsync(originalShort.Id);
            return Ok();
        }




    }
}
