using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Jcf.Challenge.BtzTransports.App.Server.Controllers
{
    [Authorize]
    public class MyController : ControllerBase
    {
        protected Guid? GetUserIdFromToken()
        {
            try
            {
                var cid = (HttpContext.User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(x => x.Type.Equals("USER_ID"));
                if (cid == null || !Guid.TryParse(cid.Value, out var id))
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
