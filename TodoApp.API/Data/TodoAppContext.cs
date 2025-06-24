using Microsoft.EntityFrameworkCore;
using TodoApp.API.Entities;

namespace TodoApp.API.Data;

public class TodoAppContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<TodoItem> TodoItems { get; set; }
}
