namespace UrlShortener.API.DTOs.Urls
{
    public class ShortenedUrlResponceDto
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Guid UserId { get; set; }
    }
}
