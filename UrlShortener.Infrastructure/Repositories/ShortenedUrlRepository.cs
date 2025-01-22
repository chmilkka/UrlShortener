using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Repositories.Interfaces;

namespace UrlShortener.Infrastructure.Repositories
{
    public class ShortenedUrlRepository(ApplicationDbContext dbContext, IHttpContextAccessor contextAccessor) : IShortenedUrlRepository
    {
        public async Task<ShortUrl> CreateShortUrlAsync(string originalUrl, User user)
        {         
            var shortenedUrl = GenerateShortenedUrl();

            var shortUrl = new ShortUrl
            {
                Id = Guid.NewGuid(),
                OriginalUrl = originalUrl,
                ShortenedUrl = shortenedUrl,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = user.Login,
            };
            try
            {
                await dbContext.ShortUrls.AddAsync(shortUrl);
                await dbContext.SaveChangesAsync();
                return shortUrl;
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Failed to save URL.");
            }   
        }

        public async Task<List<ShortUrl>> GetAllShortUrlsAsync()
        {
            return await dbContext.ShortUrls
                .OrderByDescending(url => url.CreatedAt)
                .ToListAsync();
        }

        public string GenerateShortenedUrl()
        {
            var shortCode = Guid.NewGuid().ToString("N").Substring(0, 6); 
            var baseUrl = "http://localhost:5000/"; 
            return baseUrl + shortCode;
        }
    }
}
