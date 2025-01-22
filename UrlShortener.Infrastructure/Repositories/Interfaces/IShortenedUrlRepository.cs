using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.Repositories.Interfaces
{
    public interface IShortenedUrlRepository
    {
        Task<ShortUrl> CreateShortUrlAsync(string originalUrl, User userId);
        Task<bool> DeleteUrlAsync(Guid id);
        Task<IEnumerable<ShortUrl>> GetFullUrlsDataAsync();
        Task<IEnumerable<ShortUrl>> GetRestrictedUrlsDataAsync();
        Task<string> GetOriginalUrlAsync(string shortUrl);
        Task<ShortUrl> GetUrlByIdAsync(Guid id);
    }
}
