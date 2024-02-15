using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("UserRides")]
    public class UserRides
    {
        public string AppUserId { get; set; } = string.Empty;
        public int RideId { get; set; }
        public AppUser AppUser { get; set; }
        public Ride Ride { get; set; }
    }
}