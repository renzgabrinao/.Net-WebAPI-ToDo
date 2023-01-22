using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) :
                                                        base(options)
        { }
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data. Auto-increment PK’s must 
            // still be specified in seed data.
            modelBuilder.Entity<ToDo>().HasData(
                new
                {
                    Id = 1,
                    Priority = 1,
                    Description = "Clean house",
                    IsComplete = true
                },
                new
                {
                    Id = 2,
                    Priority = 3,
                    Description = "Bake cake",
                    IsComplete = true
                }
            );
        }
    }

}
