using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.VehicleService;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VehicleServiceController : ControllerBase
    {
        private readonly IVehicleServiceRepository _vehicleServiceContext;
        private readonly IVehicleRepository _vehicleContext;

        public VehicleServiceController(IVehicleServiceRepository vehicleServiceContext, IVehicleRepository vehicleContext)
        {
            _vehicleServiceContext = vehicleServiceContext;
            _vehicleContext = vehicleContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var allServices = await _vehicleServiceContext.GetAllVehicleServices();

            var mapToVehicleServiceDTO = allServices.Select(service => service.ToVehicleServiceDTO()).ToList();

            return Ok(mapToVehicleServiceDTO);

        }

        [HttpPost("{vehicleId}")]
        public async Task<IActionResult> CreateNewServiceForVehicle([FromRoute] int vehicleId, [FromBody] CreateVehicleServiceDto createVehicleServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _vehicleContext.VehicleExists(vehicleId))
            {
                return BadRequest("Vehicle not exists!");
            }



            var mappNewData = createVehicleServiceDto.ToCreateVehicleServiceDTO(vehicleId);

            await _vehicleServiceContext.CreateNewVehicleService(mappNewData);

            return CreatedAtAction(nameof(GetServiceById), new { id = mappNewData.Id }, mappNewData.ToVehicleServiceDTO());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var service = await _vehicleServiceContext.GetVehicleServiceById(id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service.ToVehicleServiceDTO());
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateService([FromRoute] int id, [FromBody] UpdateVehicleServiceDTO updateVehicleServiceDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updatedVehicleService = await _vehicleServiceContext.UpdateVehicleService(id, updateVehicleServiceDTO);

            if (updatedVehicleService == null)
            {
                return NotFound();
            }

            return Ok(updatedVehicleService.ToVehicleServiceDTO());
        }

    }
}