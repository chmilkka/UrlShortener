using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Repositories.Interfaces;
namespace UrlShortener.Application.Services
{
    public class ShortenedUrlService(IShortenedUrlRepository _shortUrlRepository) : IShortenedUrlService
    {
        public async Task<ShortUrl> CreateShortUrlAsync(string originalUrl, User user)
        {
            return await _shortUrlRepository.CreateShortUrlAsync(originalUrl, user);
        }

        public async Task<List<ShortUrl>> GetAllShortUrlsForAdminAsync()
        {
            return await _shortUrlRepository.GetAllShortUrlsAsync();
        }
    }
}
