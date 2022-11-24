using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

var todos = new List<string> { "Go for a walk!", "Buy home groceries", "Take your pet out", "Prepare presentation" };

app.MapGet("/welcome", () => "Hello and welcome to the Minimal API Pass-It-On session!");

app.MapGet("/todos", () => todos).WithName("GetAllTodoItems");

app.MapPost("/todos", (string todo) =>
{
    todos.Add(todo);
    return Results.Ok(todos);
}).WithName("CreateTodoItem");

app.MapDelete("/todos/{id:int}", (int id) =>
{
    todos.RemoveAt(id);
    return Results.Ok(todos);
});








app.Run();