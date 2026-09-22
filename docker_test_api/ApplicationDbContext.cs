using Microsoft.EntityFrameworkCore;
using docker_test_api.Models;
namespace docker_test_api
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
