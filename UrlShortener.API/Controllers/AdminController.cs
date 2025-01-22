using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Interfaces;

namespace UrlShortener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController(IShortenedUrlService _shortenedUrlService) : ControllerBase
    {
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUrl(Guid id)
        {
            var result = await _shortenedUrlService.DeleteShortUrlAsync(id);          
            return Ok();
        }
    }
}
