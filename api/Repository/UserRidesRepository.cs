using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Rides;
using api.DTOs.Vehicle;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRidesRepository : IUserRidesRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRidesRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<RideDto>> GetRideByLocation(string StartLocation)
        {

            if (StartLocation == null)
            {
                return null;
            }

            var RideByLocation = await _context.Rides.Where(r => r.StartLocation == StartLocation).Select(ride => new RideDto
            {
                Id = ride.Id,
                AdditionalInformations = ride.AdditionalInformations,
                RideEndedOn = ride.RideEndedOn,
                RideStartedOn = ride.RideStartedOn,
                AppUserID = ride.AppUserID,
                VehicleID = ride.VehicleID,
                StartLocation = ride.StartLocation,
                EndLocation = ride.EndLocation,
                Vehicle = ride.Vehicle.ToSimplerVehicleDto(),
                AppUser = ride.AppUser.ToSimpleUserDTO()
            })
                .ToListAsync();

            return RideByLocation;
        }

        public async Task<List<RideDto>> GetUserRides(AppUser user)
        {

            if (user == null)
            {
                return null;
            }

            return await _context.Rides.AsNoTracking()
                .Where(u => u.AppUserID == user.Id)
                .Select(ride => new RideDto
                {
                    Id = ride.Id,
                    AdditionalInformations = ride.AdditionalInformations,
                    RideEndedOn = ride.RideEndedOn,
                    RideStartedOn = ride.RideStartedOn,
                    AppUserID = ride.AppUserID,
                    VehicleID = ride.VehicleID,
                    StartLocation = ride.StartLocation,
                    EndLocation = ride.EndLocation,
                    Vehicle = ride.Vehicle.ToSimplerVehicleDto(),
                    AppUser = ride.AppUser.ToSimpleUserDTO()
                })
                .ToListAsync();
        }

        public async Task<List<RideDto>> GetRideByActivity(bool isActive)
        {



            var TheRoutes = await _context.Rides.Where(r => r.IsRideActive == isActive).Select(ride => new RideDto
            {
                Id = ride.Id,
                AdditionalInformations = ride.AdditionalInformations,
                RideEndedOn = ride.RideEndedOn,
                RideStartedOn = ride.RideStartedOn,
                AppUserID = ride.AppUserID,
                VehicleID = ride.VehicleID,
                StartLocation = ride.StartLocation,
                EndLocation = ride.EndLocation,
                IsRideActive = ride.IsRideActive,
                Vehicle = ride.Vehicle.ToSimplerVehicleDto(),
                AppUser = ride.AppUser.ToSimpleUserDTO()
            })
                .ToListAsync();



            return TheRoutes;


        }

        public async Task<List<SimplerVehicleDto>> GetActiveVehicles(bool isActive)
        {


            var TheRoutes = await _context.Rides.Where(r => r.IsRideActive == isActive).Select(ride => new RideDto
            {
                Id = ride.Id,
                AdditionalInformations = ride.AdditionalInformations,
                RideEndedOn = ride.RideEndedOn,
                RideStartedOn = ride.RideStartedOn,
                AppUserID = ride.AppUserID,
                VehicleID = ride.VehicleID,
                StartLocation = ride.StartLocation,
                EndLocation = ride.EndLocation,
                IsRideActive = ride.IsRideActive,
                Vehicle = ride.Vehicle.ToSimplerVehicleDto(),
                AppUser = ride.AppUser.ToSimpleUserDTO()
            })
                .ToListAsync();

            var VehiclesAvailability = TheRoutes.Select(v => v.Vehicle).ToList();


            return VehiclesAvailability;

        }
    }
}