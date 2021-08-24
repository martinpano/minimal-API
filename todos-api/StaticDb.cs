public static class StaticDb 
{
    public static List<Todo> Todos = new List<Todo>()
    {
        new Todo 
        {
            Id = 1,
            Title = "Get my dog for a walk!",
            IsComplete = false
        },
        new Todo 
        {
            Id = 2,
            Title = "Meeting with client at 10AM!",
            IsComplete = false
        },
        new Todo 
        {
            Id = 3,
            Title = "Take a break",
            IsComplete = true
        },
    };
}