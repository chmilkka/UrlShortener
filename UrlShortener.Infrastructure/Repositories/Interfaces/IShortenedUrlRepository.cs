using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.Repositories.Interfaces
{
    public interface IShortenedUrlRepository
    {
        Task<ShortUrl> CreateShortUrlAsync(string originalUrl, User userId);
        Task<List<ShortUrl>> GetAllShortUrlsAsync();
        Task<string> GetOriginalUrlAsync(string shortUrl);
    }
}
