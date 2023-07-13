using GazpromTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GazpromTest.Services
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Well> Wells { get; set; }
    }
}
