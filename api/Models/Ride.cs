using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Rides")]

    public class Ride
    {
        public int Id { get; set; }
        public DateTime RideStartedOn { get; set; } = DateTime.Now;
        public DateTime RideEndedOn { get; set; }
        public int? VehicleID { get; set; }
        public bool IsRideActive { get; set; }
        public string? AppUserID { get; set; } = string.Empty;
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public string AdditionalInformations { get; set; } = string.Empty;
        public Vehicle Vehicle { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
        public List<UserRides> UserRides { get; set; } = new List<UserRides>();
    }
}