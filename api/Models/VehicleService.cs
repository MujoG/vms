using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("VehicleServices")]
    public class VehicleService
    {
        public int Id { get; set; }
        public string ServiceDescription { get; set; } = string.Empty;
        public string ResponsiblePerson { get; set; } = string.Empty;
        public int LastServiceMileage { get; set; }
        public DateTime ServiceCreatedOn { get; set; } = DateTime.Now;
        public int? VehicleID { get; set; }
    }
}