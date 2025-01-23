using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.API.DTOs.Urls;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Repositories.Interfaces;

namespace UrlShortener.API.Controllers
{
    [Route("api/urls")]
    [ApiController]
    public class ShortenedUrlController(IShortenedUrlService _shortenedUrlService, IUserRepository _userRepository) : ControllerBase
    {
        [Authorize]
        [HttpPost("createUrl")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("admin/delete/{id}")]
        public async Task<IActionResult> DeleteUrlByAdmin(Guid id)
        {
            var result = await _shortenedUrlService.DeleteShortUrlByAdminAsync(id);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUrlByUser(Guid id)
        {
            var result = await _shortenedUrlService.DeleteShortUrlByUserAsync(id);
            return Ok();
        }

        [HttpGet("getUrls")]
        public async Task<IActionResult> GetAllUrls()
        {
            var urls = await _shortenedUrlService.GetAllUrlsAsync();

            var restrictedUrlsResponce = urls.Select(url => new RestrictedUrlDto
            {
                ShortenedUrl = url.ShortenedUrl,
                OriginalUrl = url.OriginalUrl
            });
            return Ok(restrictedUrlsResponce);
        }

        [HttpGet("admin/getUrls")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUrlsWithDetailsForAdmins()
        {
            var urls = await _shortenedUrlService.GetAllUrlsForAdminAsync();
            return Ok(urls);
        }
    }
}
