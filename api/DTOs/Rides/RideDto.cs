using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.DTOs.Vehicle;
using api.Models;

namespace api.DTOs.Rides
{
    public class RideDto
    {
        public int Id { get; set; }
        public DateTime RideStartedOn { get; set; } = DateTime.Now;
        public DateTime RideEndedOn { get; set; }
        public int? VehicleID { get; set; }
        public string? AppUserID { get; set; } = string.Empty;
        public string StartLocation { get; set; } = string.Empty;
        public bool IsRideActive { get; set; }
        public string EndLocation { get; set; } = string.Empty;
        public string AdditionalInformations { get; set; } = string.Empty;
        public SimplerVehicleDto? Vehicle { get; set; }
        public SimpleUserDto? AppUser { get; set; }
        public List<UserRides> UserRides { get; set; } = new List<UserRides>();
    }
}