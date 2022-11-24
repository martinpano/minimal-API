using Microsoft.IdentityModel.Tokens;
using MinimalAPI.Demo.Auth.DataAccess;
using MinimalAPI.Demo.Auth.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalAPI.Demo.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly WorldCupDbContext _ctx;
        public UserService(WorldCupDbContext ctx)
        {
            _ctx = ctx;
        }
        public IResult Login(User user, string issuer, string audience, string key)
        {
            if (!string.IsNullOrEmpty(user.Username) &&
                !string.IsNullOrEmpty(user.Password))
            {
                var loggedInUser =  _ctx.Users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);

                if (loggedInUser is null) return Results.NotFound("User not found");

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
                    new Claim(ClaimTypes.Role, loggedInUser.Role)
                };

                var token = new JwtSecurityToken
                (
                    issuer,
                    audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        SecurityAlgorithms.HmacSha256)
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Results.Ok(tokenString);
            }
            return Results.BadRequest("Invalid user credentials");
        }
    }
}
