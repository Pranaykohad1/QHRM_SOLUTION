using Microsoft.EntityFrameworkCore;
using QHRM.Models;

namespace QHRM.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        
        }

        public DbSet<Product> Products { get; set; }
    }
}
