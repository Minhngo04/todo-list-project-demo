using Microsoft.EntityFrameworkCore;
using TodoBackEnd.Configuration;
using TodoBackEnd.Model;
using TodoBackEnd.Seeders;

namespace TodoBackEnd.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
            modelBuilder.Seed();
        }

        public DbSet<Todo> todos { get; set; }
    }
}
