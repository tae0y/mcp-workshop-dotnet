using McpTodoServer.ContainerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace McpTodoServer.ContainerApp.Data;

/// <summary>
/// 할 일 목록용 DbContext (SQLite In-Memory)
/// </summary>
public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> Todos => Set<TodoItem>();

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Text).IsRequired();
            entity.Property(e => e.IsCompleted).IsRequired();
        });
    }
}
