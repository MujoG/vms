using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.VehicleService;
using api.Models;

namespace api.Mappers
{
    public static class VehicleServiceMapperss
    {
        public static VehicleServiceDTO ToVehicleServiceDTO(this VehicleService vehicleServiceModel)
        {
            return new VehicleServiceDTO
            {
                Id = vehicleServiceModel.Id,
                ServiceDescription = vehicleServiceModel.ServiceDescription,
                ResponsiblePerson = vehicleServiceModel.ResponsiblePerson,
                LastServiceMileage = vehicleServiceModel.LastServiceMileage,
                VehicleID = vehicleServiceModel.VehicleID
            };
        }
        public static VehicleService ToCreateVehicleServiceDTO(this CreateVehicleServiceDto createVehicleServiceDto, int stockId)
        {
            return new VehicleService
            {
                ServiceDescription = createVehicleServiceDto.ServiceDescription,
                ResponsiblePerson = createVehicleServiceDto.ResponsiblePerson,
                LastServiceMileage = createVehicleServiceDto.LastServiceMileage,
                VehicleID = stockId
            };
        }
    }
}