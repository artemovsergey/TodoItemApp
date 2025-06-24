using FluentValidation;
using TodoApp.API.Entities;

namespace TodoApp.API.Validations;

public class TodoItemValidation : AbstractValidator<TodoItem>
{
    public TodoItemValidation()
    {
        RuleFor(u => u.Title)
            .Must(StartsWithCapitalLetter)
            .WithMessage("Название задачи должно начинаться с заглавной буквы");
    }

    private bool StartsWithCapitalLetter(string title)
    {
        return char.IsUpper(title[0]);
    }
}
