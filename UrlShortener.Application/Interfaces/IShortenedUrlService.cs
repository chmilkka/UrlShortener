using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Interfaces
{
    public interface IShortenedUrlService
    {
        Task<ShortUrl> CreateShortUrlAsync(string originalUrl, User user);
        Task<bool> DeleteShortUrlByAdminAsync(Guid id);
        Task<bool> DeleteShortUrlByUserAsync(Guid id);
        Task<IEnumerable<ShortUrl>> GetAllUrlsForAdminAsync();
        Task<IEnumerable<ShortUrl>> GetAllUrlsAsync();
        Task<string> GetOriginalUrlAsync(string shortUrl);
    }
}
