using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Rides;
using api.DTOs.VehicleService;

namespace api.DTOs.Vehicle
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string VehicleModel { get; set; } = string.Empty;
        public string RegistrationPlate { get; set; } = string.Empty;
        public int Mileage { get; set; }
        public List<VehicleServiceDTO>? VehicleServices { get; set; }
        public List<SimpleRideDTO>? Rides { get; set; }
    }
}