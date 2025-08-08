namespace URL_Shortening.Services
{
    public interface IShortUrlService
    {
        string GenerateShortUrl();
        bool CheckShortUrl(string url);


    }
}
