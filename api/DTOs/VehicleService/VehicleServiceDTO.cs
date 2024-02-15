using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.VehicleService
{
    public class VehicleServiceDTO
    {

        public int Id { get; set; }
        public string ServiceDescription { get; set; } = string.Empty;
        public string ResponsiblePerson { get; set; } = string.Empty;
        public int LastServiceMileage { get; set; }
        public DateTime ServiceCreatedOn { get; set; } = DateTime.Now;
        public int? VehicleID { get; set; }
    }
}