using Microsoft.EntityFrameworkCore;
using TodoApp.API.Data;
using TodoApp.API.Entities;
using TodoApp.API.Validations;

namespace TodoApp.API.Extensions;

public static class ApiEndpoints
{
    public static WebApplication AddApiEndpoints(this WebApplication app)
    {
        app.MapGet(
            "api/todos",
            async (ILogger<Program> log, TodoAppContext db) =>
            {
                var todos = await db.TodoItems.Select(t => new { t.Title }).ToListAsync();
                log.LogInformation("Вывод всех пользователей");
                return Results.Ok(todos);
            }
        );

        app.MapGet(
            "api/todos/{Id}",
            async (TodoAppContext db, Guid Id) =>
            {
                var todoItem = await db.TodoItems.FindAsync(Id);
                return todoItem != null
                    ? Results.Ok(todoItem)
                    : Results.NotFound($"Нет задачи с Id ={Id}");
            }
        );

        app.MapPost(
            "api/todos",
            async (TodoAppContext db, TodoItem todo) =>
            {
                var validator = new TodoItemValidation();
                var validResult = validator.Validate(todo);

                if (!validResult.IsValid)
                {
                    return Results.BadRequest(
                        $"Ошибка валидации: {validResult.Errors.FirstOrDefault()}"
                    );
                }

                try
                {
                    db.TodoItems.Add(todo);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ошибка сохранения: {ex.InnerException?.Message}");
                }
                return Results.Created(
                    $"http://localhost:5022/api/todos/{todo.Id}",
                    $"Задача {todo.Title} успешно создана!"
                );
            }
        );

        app.MapPut(
            "api/todos",
            async (TodoAppContext db, TodoItem todo) =>
            {
                try
                {
                    db.TodoItems.Update(todo);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ошибка при обновлении: {ex.InnerException?.Message}");
                }
                return Results.Ok($"Обновлена задача: {todo.Title}");
            }
        );

        app.MapDelete(
            "api/todos/{Id}",
            async (TodoAppContext db, Guid Id) =>
            {
                var todo = db.TodoItems.Find(Id);
                if (todo != null)
                {
                    db.TodoItems.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.Ok($"Удалена задача: {todo.Title} ...");
                }

                return Results.BadRequest($"Не существует задачи по {Id} ...");
            }
        );

        return app;
    }
}
