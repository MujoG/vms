using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Rides;
using api.DTOs.Vehicle;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRidesRepository
    {
        Task<List<RideDto>> GetUserRides(AppUser user);
        Task<List<RideDto>> GetRideByLocation(string StartLocation);
        Task<List<RideDto>> GetRideByActivity(bool isActive);
        Task<List<SimplerVehicleDto>> GetActiveVehicles(bool isActive);
    }
}