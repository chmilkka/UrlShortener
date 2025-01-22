using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Interfaces
{
    public interface IShortenedUrlService
    {
        Task<ShortUrl> CreateShortUrlAsync(string originalUrl, User user);
        Task<bool> DeleteShortUrlAsync(Guid id);
        Task<List<ShortUrl>> GetAllShortUrlsForAdminAsync();
        Task<string> GetOriginalUrlAsync(string shortUrl);
    }
}
