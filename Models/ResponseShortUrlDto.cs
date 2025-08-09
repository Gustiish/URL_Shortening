namespace URL_Shortening.Models
{
    public class ResponseShortUrlDto
    {
        public int Id { get; set; }
        public required string OriginalUrl { get; set; }
        public required string ShortUrl { get; set; }
        public required string CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public int AccessCount { get; set; }
    }
}
