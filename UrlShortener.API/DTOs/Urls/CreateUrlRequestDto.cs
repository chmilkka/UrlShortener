namespace UrlShortener.API.DTOs.Urls
{
    public class CreateUrlRequestDto
    {
        public string OriginalUrl { get; set; }
        public Guid UserId { get; set; }
    }
}
