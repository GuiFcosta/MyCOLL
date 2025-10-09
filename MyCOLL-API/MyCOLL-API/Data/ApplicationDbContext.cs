using Microsoft.EntityFrameworkCore;
using MyCOLL_API.Models.Entities;

namespace MyCOLL_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        // Define your DbSets here. For example:
        public DbSet<Product> Products { get; set; }

    }
}
