using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Vehicle;
using api.Models;

namespace api.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAllVehicles();
        Task<Vehicle?> GetVehicleById(int Id);
        Task<Vehicle?> CreateNewVehicle(Vehicle vehicle);
        Task<Vehicle?> UpdateVehicle(int Id, UpdateVehicleDTO updateVehicleDTO);
        Task<Vehicle?> DeleteVehicle(int Id);
        Task<bool> VehicleExists(int id);
    }
}