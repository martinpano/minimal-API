using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MinimalAPI.Demo.Auth.DataAccess;
using MinimalAPI.Demo.Auth.Models;
using MinimalAPI.Demo.Auth.Services;

namespace MinimalAPI.Demo.Auth
{
    public static class Helper
    {
        public static async Task<List<Team>> GetAllTeams(ITeamService service) => await service.GetAllTeamsAsync();

        public static async Task<IResult> GetTeamById(int id, ITeamService service) => await service.GetTeamByIdAsync(id);

        public static async Task CreateTeam(Team team, ITeamService service) => await service.AddTeamAsync(team);

        public static async Task UpdateTeam(Team team, int id, ITeamService service) => await service.UpdateTeamAsync(team, id);

        public static async Task DeleteTeam(int id, ITeamService service) => await service.DeleteTeamAsync(id);

    }
}
