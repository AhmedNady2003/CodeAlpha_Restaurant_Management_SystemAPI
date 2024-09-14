using CodeAlpha_Simple_URL_Shortener.DBContext;
using CodeAlpha_Simple_URL_Shortener.DTO;
using CodeAlpha_Simple_URL_Shortener.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CodeAlpha_Simple_URL_Shortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlManagementController : ControllerBase
    {

        private readonly MyDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlManagementController(MyDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("shorturl")]
        public async Task<IActionResult> ShortUrl(UrlDto url)
        {
            
            if(!Uri.TryCreate(url.Url, UriKind.Absolute, out var uri))
            {
                return BadRequest("Invalid URL");
            }
            var rand = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz1234567890";
            var randstr = new string (Enumerable.Repeat(chars,8).Select(x=> x[rand.Next(x.Length)]).ToArray());
            var sUrl = new UrlManagement
            {
                Url = url.Url,
                ShortUrl = randstr
            };
            _context.Urls.Add(sUrl);
            await _context.SaveChangesAsync();

            var httpContext = _httpContextAccessor.HttpContext;
            var result = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/{sUrl.ShortUrl}";

            return Ok(new UrlShortResponseDto()
            {
                Url = result
            });
        }
      
    }
}
