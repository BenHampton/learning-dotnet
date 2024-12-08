using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
        
        //todo deferred execution
        public DbSet<Stock> Stock { get; set; }
        
        public DbSet<Comment> Comment { get; set; }
    }
}