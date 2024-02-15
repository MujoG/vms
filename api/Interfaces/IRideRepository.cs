using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Rides;
using api.Models;

namespace api.Interfaces
{
    public interface IRideRepository
    {
        Task<List<Ride>> GetAllRides();
        Task<Ride?> CreateNewRide(Ride ride);
        Task<Ride?> GetRideById(int id);
        Task<Ride?> DeleteRide(int id);
        Task<Ride?> UpdateRide(int Id, Ride ride);
    }
}