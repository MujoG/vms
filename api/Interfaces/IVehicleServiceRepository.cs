using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.VehicleService;
using api.Models;

namespace api.Interfaces
{
    public interface IVehicleServiceRepository
    {
        Task<List<VehicleService>> GetAllVehicleServices();
        Task<VehicleService?> CreateNewVehicleService(VehicleService vehicleService);
        Task<VehicleService?> GetVehicleServiceById(int id);
        Task<VehicleService?> UpdateVehicleService(int id, UpdateVehicleServiceDTO updateVehicleServiceDTO);
        Task<VehicleService?> DeleteVehicleService();
    }
}