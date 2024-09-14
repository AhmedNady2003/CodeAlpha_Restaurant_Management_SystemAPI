using CodeAlpha_Simple_URL_Shortener.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeAlpha_Simple_URL_Shortener.DBContext
{
    public class MyDbContext : DbContext
    {
        public  DbSet<UrlManagement> Urls { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
    }
}
