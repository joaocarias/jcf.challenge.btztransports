using Jcf.Challenge.Server.Extensions;
using Jcf.Challenge.Server.Models;
using Jcf.Challenge.Server.Models.ViewModels;
using Jcf.Challenge.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Jcf.Challenge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RefuelingController : MyController
    {
        private readonly ILogger<RefuelingController> _logger;
        private readonly IRefuelingRepository _refuelingRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public RefuelingController(ILogger<RefuelingController> logger, IRefuelingRepository refuelingRepository, IVehicleRepository vehicleRepository, IDriverRepository driverRepository)
        {
            _logger = logger;
            _refuelingRepository = refuelingRepository;
            _vehicleRepository = vehicleRepository;
            _driverRepository = driverRepository;
        }

        #region Crud

        [HttpPost]
        public async Task<IActionResult> Create([Required] RefuelingViewModel model)
        {
            try
            {
                var driver = await _driverRepository.GetByIdAsync(model.DriverId);
                if(driver == null) BadRequest(new { driverId = model.DriverId, error = true, statusCode = HttpStatusCode.NoContent, message = "Motorista não encontrado!" });

                var vehicle = await _vehicleRepository.GetByIdAsync(model.VehicleId);
                if (vehicle == null) BadRequest(new { vehicleId = model.VehicleId, error = true, statusCode = HttpStatusCode.NoContent, message = "Veículo não encontrado!" });

                var refueling = new Refueling(model.VehicleId, model.DriverId, model.DateRefueling, model.FuelType, model.Quantity, GetUserIdFromToken());
              
                if (!refueling.FuelIsValidade(vehicle)) return BadRequest(new { vehicleId = model.VehicleId, error = true, statusCode = HttpStatusCode.BadRequest, message = "Combustível não é válido para este veículo!" });
                if (!refueling.QuantityRefueledIsValidate(vehicle)) return BadRequest(new { vehicleId = model.VehicleId, error = true, statusCode = HttpStatusCode.BadRequest, message = "Quantidade de combustível maior que o tanque do veículo consegue suporta!" });

                refueling.PaidAmount = refueling.GetPaidAmount();                                
                refueling = await _refuelingRepository.CreateAsync(refueling);
                if (refueling is null) BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Erro ao salvar o Abastecimento!" });

                return Created(refueling.Id.ToString(), new { response = new { StatusCode = HttpStatusCode.Created, message = "Cadastrado!", refueling.Id, refueling.DriverId, refueling.VehicleId, refueling.CreatedAt } });
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
                var entity = await _refuelingRepository.GetByIdAsync(id);
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
                return Ok(await _refuelingRepository.ListAllAsync());
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
                var refueling = await _refuelingRepository.GetByIdAsync(id);
                if (refueling is null) return NoContent();

                refueling.Remove(GetUserIdFromToken());
                refueling = _refuelingRepository.Update(refueling);

                if (refueling is null || refueling.IsActive.Equals(true)) return BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Aconteceu um erro a deletar o registro!" });

                return Ok(new { message = "Cadastro removido!", statusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { statusCode = HttpStatusCode.BadRequest, error = true, message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, [Required] RefuelingViewModel model)
        {
            if (id != model.Id || model is null) return NoContent();

            var driver = await _driverRepository.GetByIdAsync(model.DriverId);
            if (driver == null) BadRequest(new { driverId = model.DriverId, error = true, statusCode = HttpStatusCode.NoContent, message = "Motorista não encontrado!" });

            var vehicle = await _vehicleRepository.GetByIdAsync(model.VehicleId);
            if (vehicle == null) BadRequest(new { vehicleId = model.VehicleId, error = true, statusCode = HttpStatusCode.NoContent, message = "Veículo não encontrado!" });

            var refueling = await _refuelingRepository.GetByIdAsync(model.Id.Value);
            if (refueling is null)
                return NoContent();
            
            refueling.Update(model.VehicleId, model.DriverId, model.DateRefueling, model.FuelType, model.Quantity, GetUserIdFromToken());

            if (!refueling.FuelIsValidade(vehicle)) BadRequest(new { vehicleId = model.VehicleId, error = true, statusCode = HttpStatusCode.BadRequest, message = "Combustível não é válido para este veículo!" });
            if (!refueling.QuantityRefueledIsValidate(vehicle)) BadRequest(new { vehicleId = model.VehicleId, error = true, statusCode = HttpStatusCode.BadRequest, message = "Quantidade de combustível maior que o tanque do veículo consegue suporta!" });

            refueling.PaidAmount = refueling.GetPaidAmount();            
            refueling = _refuelingRepository.Update(refueling);
            if (refueling is null) return BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Erro ao atualizar o Abastecimento!" });
            return Ok(new
            {
                refueling.Id,
                refueling
            });
        }

        #endregion
    }
}
