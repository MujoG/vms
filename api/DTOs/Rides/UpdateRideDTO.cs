using System;
using api.DTOs.Account;
using api.DTOs.Vehicle;

namespace api.DTOs.Rides
{
    public class UpdateRideDTO
    {
        public DateTime RideStartedOn { get; set; } = DateTime.Now;
        public DateTime RideEndedOn { get; set; }
        public int VehicleID { get; set; }
        public string AppUserID { get; set; } = string.Empty;
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public bool IsRideActive { get; set; }
        public string AdditionalInformations { get; set; } = string.Empty;
    }
}
