using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Vehicle
{
    public class UpdateVehicleDTO
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Vehicle label needs to be shorter than 20 letters.")]
        public string VehicleModel { get; set; } = string.Empty;
        public string RegistrationPlate { get; set; } = string.Empty;
        public int Mileage { get; set; }
    }
}