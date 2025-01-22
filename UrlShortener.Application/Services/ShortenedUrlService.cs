using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Exceptions;
using UrlShortener.Infrastructure.Repositories.Interfaces;
namespace UrlShortener.Application.Services
{
    public class ShortenedUrlService(IShortenedUrlRepository _shortUrlRepository , IHttpContextAccessor contextAccessor) : IShortenedUrlService
    {
        public async Task<ShortUrl> CreateShortUrlAsync(string originalUrl, User user)
        {
            return await _shortUrlRepository.CreateShortUrlAsync(originalUrl, user);
        }

        public async Task<bool> DeleteShortUrlByAdminAsync(Guid id)
        {
            var url = await _shortUrlRepository.GetUrlByIdAsync(id);
            return await _shortUrlRepository.DeleteUrlAsync(id);
        }

        public async Task<bool> DeleteShortUrlByUserAsync(Guid id)
        {
            var url = await _shortUrlRepository.GetUrlByIdAsync(id);
            var userId = contextAccessor.HttpContext?.User?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (url.UserId.ToString() == userId)
            {
                return await _shortUrlRepository.DeleteUrlAsync(id);
            }
            throw new NotAuthorizedException();
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
