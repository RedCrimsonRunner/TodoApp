using TodoApp.Domain;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp.Endpoints;

public static class TodoEndpoints
{
    public static void MapTodoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/todos");

        group.MapGet("/", (ITodoRepository repo) => Results.Ok((object?)repo.GetAll()));

        group.MapGet("/{id:Guid}", (ITodoRepository repo,  Guid id) =>
        {
            if (id == Guid.Empty)
            {
                return Results.BadRequest("Id is invalid");
            }
            
            var todo = repo.GetById(id);

            return todo is null ? Results.NotFound() : Results.Ok(repo.GetById(id));
        });

        group.MapPost("/", (ITodoRepository repo, TodoDto todo) =>
        {
            if (string.IsNullOrWhiteSpace(todo.Title))
            {
                return Results.BadRequest("Title is required");
            }

            var newTodo = new Todo { Title = todo.Title };
            repo.Add(newTodo);

            return Results.Created($"/api/todos/{todo.Id}", todo);
        });

        group.MapPut("/{id:guid}", (ITodoRepository repo, Guid id, Todo updatedTodo) =>
        {
            if (id != updatedTodo.Id)
            {
                return Results.BadRequest("Id is invalid");
            }
            
            var success = repo.Update(updatedTodo);
            
            return success ? Results.NoContent() : Results.NotFound();
        });

        group.MapDelete("/{id:guid}", (ITodoRepository repo, Guid id) =>
        {
            var success = repo.Delete(id);
            return success ? Results.NoContent() : Results.NotFound();
        });
    }
}