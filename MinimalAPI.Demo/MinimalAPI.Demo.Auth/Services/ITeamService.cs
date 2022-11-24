using MinimalAPI.Demo.Auth.Models;

namespace MinimalAPI.Demo.Auth.Services
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeamsAsync();
        Task<IResult> GetTeamByIdAsync(int id);
        Task<IResult> AddTeamAsync(Team team);
        Task<IResult> UpdateTeamAsync(Team team, int id);
        Task<IResult> DeleteTeamAsync(int id);
    }
}
