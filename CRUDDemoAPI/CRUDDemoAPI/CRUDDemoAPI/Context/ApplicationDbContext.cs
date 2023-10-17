using CRUDDemoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDDemoAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Products> products { get; set; }
    }
}
