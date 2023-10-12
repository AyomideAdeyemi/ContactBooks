using ContactBook_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook_Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Contact> contact { get; set; }
        public DbSet<User> users { get; set; }
    }
}
