using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleModel { get; set; } = string.Empty;
        public string RegistrationPlate { get; set; } = string.Empty;
        public int Mileage { get; set; }
        
        public List<VehicleService> VehicleServices { get; set; } = new List<VehicleService>();
        public List<Ride> Rides { get; set; } = new List<Ride>();
    }
}