using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Vehicle;
using api.DTOs.VehicleService;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class VehicleServiceRepository : IVehicleServiceRepository
    {
        private readonly ApplicationDBContext _context;
        public VehicleServiceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<VehicleService?> CreateNewVehicleService(VehicleService vehicleService)
        {
            await _context.VehicleServices.AddAsync(vehicleService);
            await _context.SaveChangesAsync();
            return vehicleService;
        }

        public Task<VehicleService?> DeleteVehicleService()
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehicleService>> GetAllVehicleServices()
        {
            var vehicleservices = await _context.VehicleServices.ToListAsync();

            return vehicleservices;
        }

        public async Task<VehicleService?> GetVehicleServiceById(int id)
        {
            var specificService = await _context.VehicleServices.FindAsync(id);

            return specificService;
        }

        public async Task<VehicleService?> UpdateVehicleService(int id, UpdateVehicleServiceDTO updateVehicleServiceDTO)
        {
            var serviceExisting = await _context.VehicleServices.FirstOrDefaultAsync(s => s.Id == id);

            if (serviceExisting == null)
            {
                return null;
            }

            serviceExisting.ServiceDescription = updateVehicleServiceDTO.ServiceDescription;
            serviceExisting.LastServiceMileage = updateVehicleServiceDTO.LastServiceMileage;
            serviceExisting.ResponsiblePerson = updateVehicleServiceDTO.ResponsiblePerson;

            await _context.SaveChangesAsync();

            return serviceExisting;
        }
    }
}