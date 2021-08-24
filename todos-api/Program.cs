using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("TodoDb") ?? "Server=.;Database=NotesDemoDb;Trusted_Connection=True";
builder.Services.AddDbContext<TodoDb>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

await EnsureDb(connectionString, app.Logger);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/todos", () => StaticDb.Todos.ToList());

app.MapGet("/todos/{id}", (int id) => {
    return StaticDb.Todos.SingleOrDefault(x => x.Id == id);
});

app.MapPost("/todos", (Todo todo) => {
    StaticDb.Todos.Add(todo);
    return Results.Ok("Todo added successfully!");
});

app.Run();


async Task EnsureDb(string connectionString, ILogger logger)
{
    logger.LogInformation("Ensuring database exists at connection string '{connectionString}'", connectionString);

    var options = new DbContextOptionsBuilder<TodoDb>().UseSqlServer(connectionString).Options;
    using var db = new TodoDb(options);
    await db.Database.MigrateAsync();
}



public class Todo 
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
};


public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}