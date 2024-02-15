using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Vehicle;
using api.Models;

namespace api.Mappers
{
    public static class VehicleMappers
    {
        public static VehicleDTO ToVehicleDTO(this Vehicle vehicleModel)
        {
            return new VehicleDTO
            {
                Id = vehicleModel.Id,
                VehicleModel = vehicleModel.VehicleModel,
                RegistrationPlate = vehicleModel.RegistrationPlate,
                Mileage = vehicleModel.Mileage,
                VehicleServices = vehicleModel.VehicleServices.Select(vs => vs.ToVehicleServiceDTO()).ToList(),
                Rides = vehicleModel.Rides.Select(r => r.ToSimpleRideDTO()).ToList()
            };
        }
        public static Vehicle ToCreateVehicleDTO(this CreateVehicleDTO newVehicleContext)
        {
            return new Vehicle
            {
                VehicleModel = newVehicleContext.VehicleModel,
                RegistrationPlate = newVehicleContext.RegistrationPlate,
                Mileage = newVehicleContext.Mileage
            };
        }
        public static SimplerVehicleDto ToSimplerVehicleDto(this Vehicle newVehicleContext)
        {
            return new SimplerVehicleDto
            {
                Id = newVehicleContext.Id,
                VehicleModel = newVehicleContext.VehicleModel,
                RegistrationPlate = newVehicleContext.RegistrationPlate,
                Mileage = newVehicleContext.Mileage
            };
        }
    }
}