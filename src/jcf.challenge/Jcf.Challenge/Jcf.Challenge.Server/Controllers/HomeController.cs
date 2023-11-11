using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.Challenge.Server.Controllers
{
    public class HomeController : MyController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetInformations()
        {
            try
            {                
                return Ok(new { 
                    Address = "Av. das Palmeiras, 40 – Maringá – PR",
                    Fones = "(44) 3246-4144 / (44) 99999-8888 (whats)",
                    Email = "sac@btztransports.com.br",
                    HorarioAtendimento = "seg/sex – 08h00 – 22h00"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }
    }
}
