using Microsoft.EntityFrameworkCore;
using TodoApp.API.Data;
using TodoApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoAppContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"))
);

var app = builder.Build();
app.UseMiddleware<TodoApp.API.Middlewares.ExceptionHandlerMiddleware>();
app.AddApiEndpoints();
app.Run();
