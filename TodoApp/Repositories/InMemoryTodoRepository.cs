using TodoApp.Domain;

namespace TodoApp.Repositories;

public class InMemoryTodoRepository : ITodoRepository
{
    private readonly List<Todo> _todos = new();
    
    public IEnumerable<Todo> GetAll() => _todos;

    public Todo? GetById(Guid id) => 
        _todos.FirstOrDefault(t => t.Id == id);

    public void Add(Todo todo) => _todos.Add(todo);
    
    public bool Update(Todo todo)
    {
        var existing = _todos.FirstOrDefault(t => t.Id == todo.Id);
        if (existing is null)
        {
            return false;
        }
        
        existing.Title = todo.Title;
        existing.IsCompleted = todo.IsCompleted;

        return true;
    }

    public bool Delete(Guid id)
    {
        var todo = GetById(id);
        if (todo is null)
        {
            return false;
        }

        _todos.Remove(todo);
        
        return true;
    }
}