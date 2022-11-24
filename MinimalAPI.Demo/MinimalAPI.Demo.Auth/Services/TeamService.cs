using Microsoft.EntityFrameworkCore;
using MinimalAPI.Demo.Auth.DataAccess;
using MinimalAPI.Demo.Auth.Models;

namespace MinimalAPI.Demo.Auth.Services
{
    public class TeamService : ITeamService
    {
        private readonly WorldCupDbContext _ctx;
        public TeamService(WorldCupDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Team>> GetAllTeamsAsync() => await _ctx.Teams.ToListAsync();

        public async Task<IResult> GetTeamByIdAsync(int id) => await _ctx.Teams.FindAsync(id) is Team team ? Results.Ok(team) : Results.NotFound("Sorry no such team :(");


        public async Task<IResult> AddTeamAsync(Team team)
        {
            _ctx.Teams.Add(team);
            await _ctx.SaveChangesAsync();
            return Results.Created("Team created successfully!", GetAllTeamsAsync());
        }

        public async Task<IResult> UpdateTeamAsync(Team team, int id)
        {
            var teamFromDb = await _ctx.Teams.FindAsync(id);
            if (teamFromDb is null) return Results.NotFound("No such team to be updated!");

            teamFromDb.Name = team.Name;
            teamFromDb.Group = team.Group;
            await _ctx.SaveChangesAsync();
            return Results.Ok(await GetAllTeamsAsync());
        }

        public async Task<IResult> DeleteTeamAsync(int id)
        {
            var team = await _ctx.Teams.FindAsync(id);
            if (team is null) return Results.NotFound("No such team to be deleted!");

            _ctx.Teams.Remove(team);
            await _ctx.SaveChangesAsync();
            return Results.Ok(await GetAllTeamsAsync());
        }
    }
}
