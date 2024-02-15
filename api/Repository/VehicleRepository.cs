using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Vehicle;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class VehicleRepository : IVehicleRepository
    {

        private readonly ApplicationDBContext _context;
        public VehicleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Vehicle?> CreateNewVehicle(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle?> DeleteVehicle(int Id)
        {
            var vehicleForDelete = await _context.Vehicles.FindAsync(Id);

            if (vehicleForDelete == null)
            {
                return null;
            }

            _context.Remove(vehicleForDelete);
            await _context.SaveChangesAsync();

            return vehicleForDelete;
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            var vehicles = await _context.Vehicles.Include(vs => vs.VehicleServices).Include(r => r.Rides).ToListAsync();

            return vehicles;
        }

        public async Task<Vehicle?> GetVehicleById(int Id)
        {
            var vehicleById = await _context.Vehicles.Include(vs => vs.VehicleServices).Include(r => r.Rides).FirstOrDefaultAsync(i => i.Id == Id);

            return vehicleById;
        }

        public async Task<Vehicle?> UpdateVehicle(int Id, UpdateVehicleDTO updateVehicleDTO)
        {
            var vehicleExisting = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == Id);

            if (vehicleExisting == null)
            {
                return null;
            }

            vehicleExisting.VehicleModel = updateVehicleDTO.VehicleModel;
            vehicleExisting.RegistrationPlate = updateVehicleDTO.RegistrationPlate;
            vehicleExisting.Mileage = updateVehicleDTO.Mileage;

            await _context.SaveChangesAsync();

            return vehicleExisting;

        }

        public Task<bool> VehicleExists(int id)
        {
            return _context.Vehicles.AnyAsync(v => v.Id == id);
        }
    }
}