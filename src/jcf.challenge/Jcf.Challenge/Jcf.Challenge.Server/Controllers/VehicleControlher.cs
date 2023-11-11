using Microsoft.AspNetCore.Mvc;

namespace Jcf.Challenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VehicleControlher : MyController
    {
        private readonly ILogger<VehicleControlher> _logger;


    }
}
