namespace TodoApp.Domain;

public class Todo
{
    public Guid Id { get; init; } =  Guid.NewGuid();
    
    public string Title { get; set; } =  string.Empty;
    
    public bool IsCompleted { get; set; }
}