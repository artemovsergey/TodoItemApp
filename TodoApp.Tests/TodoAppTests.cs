using TodoApp.API.Entities;

namespace TodoApp.Tests;

public class TodoAppTests
{
    [Fact]
    public void CreateTask_IsCreated()
    {
        var todoItem = new TodoItem { Title = "Test task" };
        Assert.False(todoItem.IsCompleted);
    }
}
