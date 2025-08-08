namespace URL_Shortening.Models
{
    public class ShortURL
    {

        public int Id { get; private set; }
        public string OriginalUrl { get; set; } = "";
        public string ShortUrl { get; set; } = "";
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }
        public int AccessCount { get; set; }

        public ShortURL()
        {
            CreatedAt = DateTime.Now;
        }

    }
}
