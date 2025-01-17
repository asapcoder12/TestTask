using Microsoft.EntityFrameworkCore;
using TestTask.Entities;

namespace TestTask.DataAccess.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Citizen> Citizens { get; set; }
    }
}
