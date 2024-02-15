using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.VehicleService
{
    public class UpdateVehicleServiceDTO
    {
        [Required]
        public string ServiceDescription { get; set; } = string.Empty;
        public string ResponsiblePerson { get; set; } = string.Empty;
        public int LastServiceMileage { get; set; }
    }
}