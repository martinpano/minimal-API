using Microsoft.EntityFrameworkCore;
using MinimalAPI.Demo.EF.DataAccess;
using MinimalAPI.Demo.EF.DataAccess.Models;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WorldCupDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


#region Helpers
async Task<List<Team>> GetAllTeams(WorldCupDbContext ctx)
{
    return await ctx.Teams.ToListAsync();
}

#endregion

app.MapGet("/welcome", () => "Welcome to the 2022 world cup in Qatar!");

#region Routes
app.MapGet("/teams", async (WorldCupDbContext ctx) => await ctx.Teams.ToListAsync());

app.MapGet("/teams/{id:int}", async (WorldCupDbContext ctx, int id) =>
                        await ctx.Teams.FindAsync(id) is Team team ?
                        Results.Ok(team) :
                        Results.NotFound("Sorry no such team :("));

app.MapPost("/teams", async (WorldCupDbContext ctx, Team team) =>
{
    ctx.Teams.Add(team);
    await ctx.SaveChangesAsync();
    return Results.Created("Team created successfully!", await GetAllTeams(ctx));
});

app.MapPut("/teams/{id:int}", async (WorldCupDbContext ctx, Team team, int id) =>
{
    var teamFromDb = await ctx.Teams.FindAsync(id);
    if (teamFromDb is null) return Results.NotFound("No such team to be updated!");

    teamFromDb.Name = team.Name;
    teamFromDb.Group = team.Group;
    await ctx.SaveChangesAsync();
    return Results.Ok(await GetAllTeams(ctx));
});

app.MapDelete("/teams/{id:int}", async (WorldCupDbContext ctx, int id) =>
{
    var team = await ctx.Teams.FindAsync(id);
    if (team is null) return Results.NotFound("No such team to be deleted!");

    ctx.Teams.Remove(team);
    await ctx.SaveChangesAsync();
    return Results.Ok(await GetAllTeams(ctx));
});
#endregion




app.Run();