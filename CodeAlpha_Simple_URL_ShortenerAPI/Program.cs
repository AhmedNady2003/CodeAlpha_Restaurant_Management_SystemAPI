
using CodeAlpha_Simple_URL_Shortener.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CodeAlpha_Simple_URL_Shortener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<MyDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.MapFallback(async (MyDbContext _context, HttpContext _httpContext) =>
            {
                var path = _httpContext.Request.Path.ToUriComponent().Trim('/');
                var UrlMatch = await _context.Urls.FirstOrDefaultAsync(x => x.ShortUrl.Trim() == path.Trim());
                if (UrlMatch == null)
                    return Results.NotFound();
                return Results.Redirect(UrlMatch.Url);
            });
            app.Run();
        }

        
    }
}
