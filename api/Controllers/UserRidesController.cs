using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserRidesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRideRepository _rideRepository;
        private readonly IUserRidesRepository _userRidesRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public UserRidesController(UserManager<AppUser> userManager, IRideRepository rideRepository, IUserRidesRepository userRidesRepository, IVehicleRepository vehicleRepository)
        {
            _userManager = userManager;
            _rideRepository = rideRepository;
            _userRidesRepository = userRidesRepository;
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserRides()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userRides = await _userRidesRepository.GetUserRides(appUser);

            return Ok(userRides);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetRidesByUsername([FromRoute] string username)
        {
            // var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userRides = await _userRidesRepository.GetUserRides(appUser);

            if (appUser == null)
            {
                return BadRequest("No user with that username");
            }

            return Ok(userRides);
        }

        [HttpGet("location/{StartLocation}")]
        public async Task<IActionResult> GetRideByStartLocation([FromRoute] string StartLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userRides = await _userRidesRepository.GetRideByLocation(StartLocation);

            return Ok(userRides);

        }
        [HttpGet("vehicle/{isActive}")]
        public async Task<IActionResult> GetActiveOrNonActiveRides([FromRoute] bool isActive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var theroutes = await _userRidesRepository.GetRideByActivity(isActive);

            return Ok(theroutes);

        }

        [HttpGet]
        [Route("/activeVehicles")]
        public async Task<IActionResult> GetActiveVehicles()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var acticeVehicles = await _userRidesRepository.GetActiveVehicles(true);

            return Ok(acticeVehicles);
        }

        [HttpGet]
        [Route("/availableVehicles")]
        public async Task<IActionResult> GetNotActiveVehicles()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var activeVehicles = await _userRidesRepository.GetActiveVehicles(true);

            var allVehicles = await _vehicleRepository.GetAllVehicles();

            var notActiveVehicles = allVehicles
                .Where(vehicle => !activeVehicles.Any(activeVehicle => activeVehicle.Id == vehicle.Id))
                .Select(vehicle => vehicle.ToSimplerVehicleDto())
                .ToList();

            return Ok(notActiveVehicles);
        }
    }

}