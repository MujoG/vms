using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Vehicle;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly IVehicleRepository _vehicleContext;

        public VehicleController(IVehicleRepository vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Problem");
            }

            var vehicles = await _vehicleContext.GetAllVehicles();

            var mapVehicles = vehicles.Select(vehicle => vehicle.ToVehicleDTO()).ToList();

            return Ok(mapVehicles);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewVehicle([FromBody] CreateVehicleDTO newVehicleContext)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is not good!");
            }

            var vehicleModel = newVehicleContext.ToCreateVehicleDTO();

            await _vehicleContext.CreateNewVehicle(vehicleModel);

            Console.WriteLine($"New vehicle created: {newVehicleContext}");

            return Ok(newVehicleContext);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vehicle = await _vehicleContext.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle.ToVehicleDTO());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateVehicle([FromRoute] int id, [FromBody] UpdateVehicleDTO updatedVehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateVehicle = await _vehicleContext.UpdateVehicle(id, updatedVehicle);

            if (updatedVehicle == null)
            {
                return NotFound();
            }

            return Ok(updateVehicle.ToVehicleDTO());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] int id)
        {
            var deleteVehicle = await _vehicleContext.DeleteVehicle(id);

            if (deleteVehicle == null)
            {
                return NotFound();
            }

            return NoContent();

        }



    }
}