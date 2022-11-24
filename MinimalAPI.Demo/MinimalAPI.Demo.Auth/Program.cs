using Microsoft.AspNetCore.Authentication.JwtBearer;
using MinimalAPI.Demo.Auth;
using MinimalAPI.Demo.Auth.Models;
using MinimalAPI.Demo.Auth.Services;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);


ConfigureService.Configure(builder);

var app = builder.Build();

ConfigureMiddleware.Configure(app, app.Environment);


app.MapPost("/login", (User user, IUserService service) => service.Login(user, builder.Configuration["Jwt:Issuer"], builder.Configuration["Jwt:Audience"], builder.Configuration["Jwt:Key"]));
//app.MapGet("/teams", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")] () => Helper.GetAllTeams);
app.MapGet("/teams", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")] async (ITeamService service) =>
{
    return await service.GetAllTeamsAsync();
});
app.MapGet("/teams/{id:int}", Helper.GetTeamById);
app.MapPost("/teams", Helper.CreateTeam);
app.MapPut("/teams/{id:int}", Helper.UpdateTeam);
app.MapDelete("/teams/{id:int}", Helper.DeleteTeam);

app.Run();
