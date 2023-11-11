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
                var informations = new List<string>
                {
                    "Endereço: Av. das Palmeiras, 40 – Maringá – PR",
                    "Contato: (44) 3246-4144 / (44) 99999-8888 (whats) - sac@btztransports.com.br",
                    "Horário de atendimento: seg/sex – 08h00 – 22h00"
                };
                return Ok(informations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);  
            }
        }
    }
}
