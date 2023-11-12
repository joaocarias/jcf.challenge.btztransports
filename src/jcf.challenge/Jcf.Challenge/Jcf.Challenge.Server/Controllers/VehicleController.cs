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
    public class VehicleControlher : MyController
    {
        private readonly ILogger<VehicleControlher> _logger;
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleControlher(ILogger<VehicleControlher> logger, IVehicleRepository vehicleRepository)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
        }

        #region Crud

        [HttpPost]
        public async Task<IActionResult> Create([Required] CreateVehicleViewModel model)
        {
            try
            {
                if (await _vehicleRepository.PlateInUse(model.Plate))
                    return Conflict(new { StatusCode = HttpStatusCode.Conflict, error = true, message = "Placa já cadastrado!", model.Plate });

                var vehicle = new Vehicle(model.Plate, model.Name, model.FuelType, model.Manufacturer, model.YearManufacture, model.MaxCapacityFuel, model.Observation, GetUserIdFromToken());
                vehicle = await _vehicleRepository.CreateAsync(vehicle);
                if (vehicle is null) BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Erro ao salvar o Veículo!" });

                return Created(vehicle.Id.ToString(), new { response = new { StatusCode = HttpStatusCode.Created, message = "Cadastrado!", vehicle.Id, vehicle.Name, vehicle.Plate, vehicle.Manufacturer, vehicle.CreatedAt } })  ;
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
                var entity = await _vehicleRepository.GetByIdAsync(id);
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
                return Ok(await _vehicleRepository.ListAllAsync());
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
                var vehicle = await _vehicleRepository.GetByIdAsync(id);
                if (vehicle is null) return NoContent();

                vehicle.Remove(GetUserIdFromToken());
                vehicle = _vehicleRepository.Update(vehicle);

                if (vehicle is null || vehicle.IsActive.Equals(true)) return BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Aconteceu um erro a deletar o registro!" });

                return Ok(new { message = "Cadastro removido!", statusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { statusCode = HttpStatusCode.BadRequest, error = true, message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([Required] Guid id, [Required] Vehicle updateVehicle)
        {
            if (id != updateVehicle.Id) return NoContent();

            var vehicle = await _vehicleRepository.GetByIdAsync(updateVehicle.Id);
            if (vehicle is null)
                return NoContent();
                        
            vehicle.Update(updateVehicle.Plate, updateVehicle.Name, updateVehicle.FuelType, updateVehicle.Manufacturer, updateVehicle.YearManufacture, updateVehicle.MaxCapacityFuel, updateVehicle.Observation, GetUserIdFromToken());
            vehicle = _vehicleRepository.Update(vehicle);
            if (vehicle is null) return BadRequest(new { statusCode = HttpStatusCode.BadGateway, error = true, message = "Erro ao atualizar o Motorista!" });
            return Ok(new
            {
                vehicle.Id,
                vehicle
            });
        }

        #endregion
    }
}
