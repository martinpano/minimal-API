using MinimalAPI.Demo.Auth.Models;

namespace MinimalAPI.Demo.Auth.Services
{
    public interface IUserService
    {
       IResult Login(User user, string issuer, string audience, string key);
    }
}
