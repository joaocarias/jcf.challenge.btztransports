using Jcf.Challenge.Server.Enums;
using Jcf.Challenge.Server.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.Challenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UtilController : MyController
    {
        private readonly ILogger<UtilController> _logger;
        private readonly IConfiguration _configuration;

        public UtilController(ILogger<UtilController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> FuelTypeDescription(EFuelType fuelType)
        {
            try
            {
                var fuelTypeResume = _configuration.GetSection($"FuelTypes:{fuelType.ToString()}").Get<FuelTypeDescriptionViewModel>();
                if(fuelTypeResume is null) return BadRequest(new { error = true, message = "Descrição não encontrada" });

                return Ok(fuelTypeResume);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> FuelTypeAllDescriptions()
        {
            try
            {                
                return Ok(_configuration.GetSection("FuelTypes").Get<IList<FuelTypeDescriptionViewModel>>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }
    }
}
