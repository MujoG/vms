using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Vehicle
{
    public class CreateVehicleDTO
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Maximal Length for Vehicle label is 20 characters.")]
        public string VehicleModel { get; set; } = string.Empty;
        public string RegistrationPlate { get; set; } = string.Empty;
        [Range(1, 300000)]
        public int Mileage { get; set; }
    }
}