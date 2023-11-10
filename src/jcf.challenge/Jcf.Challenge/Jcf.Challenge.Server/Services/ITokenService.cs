using Jcf.Challenge.Server.Models;
using System.Security.Claims;

namespace Jcf.Challenge.Server.Services
{
    public interface ITokenService
    {
        ClaimsIdentity GeneratorClaims(User user);
        string NewToken(User user);
    }
}
