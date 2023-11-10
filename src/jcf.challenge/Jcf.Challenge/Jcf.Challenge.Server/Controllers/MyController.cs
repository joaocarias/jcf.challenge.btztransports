using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Jcf.Challenge.Server.Controllers
{
    public class MyController : ControllerBase
    {     
        protected Guid? GetUserIdFromToken()
        {
            try
            {
                var userId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(x => x.Type.Equals("USER_ID"));
                if (userId is null || !Guid.TryParse(userId.Value, out var id))
                    return null;
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("1" + ex.ToString());
            }

            return null;
        }
    }
}
