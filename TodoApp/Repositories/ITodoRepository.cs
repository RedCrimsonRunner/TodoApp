using TodoApp.Domain;

namespace TodoApp.Repositories;

public interface ITodoRepository
{
    IEnumerable<Todo> GetAll();
    
    Todo? GetById(Guid id);

    void Add(Todo todo);

    bool Update(Todo todo);
    
    bool Delete(Guid id);
}