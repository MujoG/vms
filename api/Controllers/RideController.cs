using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Rides;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRideRepository _rideRepository;
        public RideController(UserManager<AppUser> userManager, IVehicleRepository vehicleRepository, IRideRepository rideRepository)
        {
            _userManager = userManager;
            _vehicleRepository = vehicleRepository;
            _rideRepository = rideRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRides()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var allRides = await _rideRepository.GetAllRides();

            var mapRides = allRides.Select(ride => ride.ToRideDTO()).ToList();



            return Ok(mapRides);

        }
        [HttpPost]
        public async Task<IActionResult> CreateNewRide([FromBody] CreateRideDTO createRideDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("DESCRIPTION");
            }

            if (!await _vehicleRepository.VehicleExists(createRideDTO.VehicleID))
            {
                return BadRequest("Vehicle not exists!");
            }

            var driverById = await _userManager.FindByIdAsync(createRideDTO.AppUserID);

            if (driverById == null)
            {
                return BadRequest("Username not exists!");
            }

            var VehicleByVehicleID = await _vehicleRepository.GetVehicleById(createRideDTO.VehicleID);

            var modelForRepository = new Ride
            {
                RideStartedOn = createRideDTO.RideStartedOn,
                RideEndedOn = createRideDTO.RideEndedOn,
                VehicleID = createRideDTO.VehicleID,
                AppUserID = createRideDTO.AppUserID,
                StartLocation = createRideDTO.StartLocation,
                EndLocation = createRideDTO.EndLocation,
                AdditionalInformations = createRideDTO.AdditionalInformations,
                Vehicle = VehicleByVehicleID,
                AppUser = driverById,
                IsRideActive = createRideDTO.IsRideActive,

            };

            var newRide = await _rideRepository.CreateNewRide(modelForRepository);

            var newRideToDTO = newRide.ToRideDTO();

            return Ok(newRideToDTO);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRide([FromRoute] int id)
        {
            var routeDelete = await _rideRepository.DeleteRide(id);

            if (routeDelete == null)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateRide([FromRoute] int id, UpdateRideDTO updateRideDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var VehicleByVehicleID = await _vehicleRepository.GetVehicleById(updateRideDTO.VehicleID);
            var driverById = await _userManager.FindByIdAsync(updateRideDTO.AppUserID);


            var modelForRepository = new Ride
            {
                RideStartedOn = updateRideDTO.RideStartedOn,
                RideEndedOn = updateRideDTO.RideEndedOn,
                VehicleID = updateRideDTO.VehicleID,
                AppUserID = updateRideDTO.AppUserID,
                StartLocation = updateRideDTO.StartLocation,
                EndLocation = updateRideDTO.EndLocation,
                AdditionalInformations = updateRideDTO.AdditionalInformations,
                Vehicle = VehicleByVehicleID,
                IsRideActive = updateRideDTO.IsRideActive,
                AppUser = driverById
            };

            var updateRide = await _rideRepository.UpdateRide(id, modelForRepository);

            if (updateRide == null)
            {
                return NotFound();
            }

            return Ok(updateRide);
        }

    }
}