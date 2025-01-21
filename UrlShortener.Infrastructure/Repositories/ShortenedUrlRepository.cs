using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Repositories.Interfaces;

namespace UrlShortener.Infrastructure.Repositories
{
    public class ShortenedUrlRepository(ApplicationDbContext _dbContext) : IShortenedUrlRepository
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

            await _dbContext.ShortUrls.AddAsync(shortUrl);
            await _dbContext.SaveChangesAsync();

            return shortUrl;
        }

        public async Task<List<ShortUrl>> GetAllShortUrlsAsync()
        {
            return await _dbContext.ShortUrls
                .OrderByDescending(url => url.CreatedAt)
                .ToListAsync();
        }

        public string GenerateShortenedUrl()
        {
            var shortCode = Guid.NewGuid().ToString("N").Substring(0, 6); // Генерация уникального кода
            var baseUrl = "http://localhost:5000/"; // Локальный URL для коротких ссылок
            return baseUrl + shortCode; // Возвращаем полную короткую ссылку
        }
    }
}
