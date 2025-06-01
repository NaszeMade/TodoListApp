using Microsoft.EntityFrameworkCore;
using TodoListApp.Model; // Ensure this matches the namespace of TodoItem

namespace TodoListApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}