namespace TodoApp.API.Entities;

public class TodoItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; } = default!;
    public bool IsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
