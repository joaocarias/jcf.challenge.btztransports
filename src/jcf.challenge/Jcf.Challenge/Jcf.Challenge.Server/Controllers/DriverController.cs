using Jcf.Challenge.Server.Models;
using Jcf.Challenge.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Jcf.Challenge.Server.Extensions;

namespace Jcf.Challenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DriverController : MyController
    {
        private readonly ILogger<DriverController> _logger;
        private readonly IDriverRepository _driverRepository;

        public DriverController(ILogger<DriverController> logger, IDriverRepository driverRepository)
        {
            _logger = logger;
            _driverRepository = driverRepository;
        }

        #region Crud

        [HttpPost]
        public async Task<IActionResult> Create([Required] Driver driver)
        {
            try
            {
                if (await _driverRepository.DocumentNumberInUse(driver.DocumentNumber.OnlyNumbers()))
                    return Conflict(new { StatusCode = HttpStatusCode.Conflict, error = true, message = "Documento CPF já cadastrado!", driver.DocumentNumber });

                if (await _driverRepository.LicenseNumberInUse(driver.LicenseNumber.OnlyNumbers()))
                    return Conflict(new { StatusCode = HttpStatusCode.Conflict, error = true, message = "Documento CHN já cadastrado!", driver.LicenseNumber });

                driver.UserCreateId = GetUserIdFromToken();
                driver = await _driverRepository.CreateAsync(driver);
                if (driver is null) BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Erro ao criar Motorista!" });

                return Created(driver.Id.ToString(), new { response = new { StatusCode = HttpStatusCode.Created, message = "Cadastrado!", driver.Id, driver.Name, driver.FirstName, driver.CreatedAt } });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { StatusCode = HttpStatusCode.BadRequest, error = true, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            try
            {
                var entity = await _driverRepository.GetByIdAsync(id);
                if (entity is null) return NoContent();
                              
                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _driverRepository.ListAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { error = true, message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            try
            {
                var driver = await _driverRepository.GetByIdAsync(id);
                if (driver is null) return NoContent();
                
                driver.Remove(GetUserIdFromToken());                                
                driver = _driverRepository.Update(driver);

                if (driver is null || driver.IsActive.Equals(true)) return BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Aconteceu um erro a deletar o registro!" });

                return Ok(new { message = "Cadastro apagado!", statusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { statusCode = HttpStatusCode.BadRequest, error = true, message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, [Required] Driver updateDriver)
        {
            if (id != updateDriver.Id) return NoContent();

            var driver = await _driverRepository.GetByIdAsync(updateDriver.Id);
            if (driver is null)
                return NoContent();

            driver.Update(updateDriver.Name, updateDriver.DocumentNumber, updateDriver.LicenseNumber, updateDriver.LicenseCategories, updateDriver.DateOfBirth, updateDriver.Status, GetUserIdFromToken());
            driver = _driverRepository.Update(driver);
            if (driver is null) return BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Erro ao atualizar o Motorista!" });            
            return Ok(new
            {
                driver.Id,
                driver
            });
        }
    
        #endregion
    }
}
