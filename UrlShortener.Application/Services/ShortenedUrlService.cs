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

        public async Task<bool> DeleteShortUrlAsync(Guid id)
        {
            var url = await _shortUrlRepository.GetUrlByIdAsync(id);
            return await _shortUrlRepository.DeleteUrlAsync(id);
        }

        public async Task<IEnumerable<ShortUrl>> GetAllUrlsForAdminAsync()
        {
            return await _shortUrlRepository.GetFullUrlsDataAsync();
        }

        public async Task<IEnumerable<ShortUrl>> GetAllUrlsAsync()
        {
            return await _shortUrlRepository.GetRestrictedUrlsDataAsync();
        }

        public async Task<string> GetOriginalUrlAsync(string shortUrl)
        {
            try
            {
                return await _shortUrlRepository.GetOriginalUrlAsync(shortUrl);
            }
            catch(Exception)
            {
                throw new KeyNotFoundException("Shortened URL not found.");
            }           
        }
    }
}
