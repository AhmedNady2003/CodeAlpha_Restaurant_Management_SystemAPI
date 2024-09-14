using CodeAlpha_Event_Registration_SystemMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeAlpha_Event_Registration_SystemMVC.DBContext
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }

    }
}
