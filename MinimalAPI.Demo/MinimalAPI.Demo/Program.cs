var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

var todos = new List<string> { "Go for a walk!", "Buy home groceries", "Take your pet out", "Prepare presentation" };



app.MapGet("/welcome", () => "Hello and welcome to the Minimal API Pass-It-On session!");

app.MapGet("/hello", (HttpContext context) => $"Hello there {context.Request.Query["fName"]} {context.Request.Query["lName"]}");

app.MapGet("/todos", () => Results.Ok(todos))
    .Produces<List<string>>()
    .WithName("GetAllTodoItems"); ;

app.MapPost("/todos", (string todo) =>
{
    todos.Add(todo);
    return Results.Ok(todos);
}).Produces<string>(StatusCodes.Status201Created)
  .WithName("CreateTodoItem");



app.MapDelete("/todos/{id:int}", (int id) =>
{
    todos.RemoveAt(id);
    return Results.Ok(todos);
});








app.Run();