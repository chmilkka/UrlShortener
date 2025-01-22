using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.API.DTOs.Urls;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Repositories.Interfaces;

namespace UrlShortener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenedUrlController(IShortenedUrlService _shortenedUrlService, IUserRepository _userRepository) : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateShortUrl([FromBody] CreateUrlRequestDto request)
        {          
            var user = await _userRepository.GetUserByIdAsync(request.UserId);          
            var shortenedUrl = await _shortenedUrlService.CreateShortUrlAsync(request.OriginalUrl, user);

            var shortenedUrlResponce = new ShortenedUrlResponceDto
            {
                Id = shortenedUrl.Id,
                OriginalUrl = shortenedUrl.OriginalUrl,
                ShortenedUrl = shortenedUrl.ShortenedUrl,
                CreatedAt = shortenedUrl.CreatedAt,
                CreatedBy = shortenedUrl.CreatedBy,
                UserId = shortenedUrl.UserId 
            };

            return Ok(shortenedUrlResponce);
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string shortUrl)
        {
            var decodedUrl = Uri.UnescapeDataString(shortUrl);
            var originalUrl = await _shortenedUrlService.GetOriginalUrlAsync(decodedUrl);
         
            return Redirect(originalUrl);
        }
    }
}
