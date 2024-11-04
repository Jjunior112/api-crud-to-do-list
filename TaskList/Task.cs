public class Task 
{
    public Guid id {get; init;}
    public string Title {get; private set;}
    public bool Priority {get; private set;}

    public Task(string title)
    {
        id = Guid.NewGuid();
        Title = title;
        Priority = false;
    }
}