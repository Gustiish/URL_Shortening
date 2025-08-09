namespace URL_Shortening.Services.Interfaces
{
    public interface IBuilderService
    {
        string GenerateShortUrl();
        bool CheckShortUrl(string url);
    }
}
