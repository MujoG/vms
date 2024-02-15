using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Rides;
using api.Models;

namespace api.Mappers
{
    public static class RidesMappers
    {
        public static RideDto ToRideDTO(this Ride ride)
        {
            return new RideDto
            {
                Id = ride.Id,
                RideEndedOn = ride.RideEndedOn,
                RideStartedOn = ride.RideStartedOn,
                VehicleID = ride.VehicleID,
                AppUserID = ride.AppUserID,
                StartLocation = ride.StartLocation,
                EndLocation = ride.EndLocation,
                AdditionalInformations = ride.AdditionalInformations,
                UserRides = ride.UserRides,
                IsRideActive = ride.IsRideActive,
                Vehicle = ride.Vehicle.ToSimplerVehicleDto(),
                AppUser = ride.AppUser.ToSimpleUserDTO()
            };
        }

        public static Ride ToCreateRideDTO(this CreateRideDTO ride)
        {
            return new Ride
            {
                RideEndedOn = ride.RideEndedOn,
                RideStartedOn = ride.RideStartedOn,
                VehicleID = ride.VehicleID,
                AppUserID = ride.AppUserID,
                StartLocation = ride.StartLocation,
                EndLocation = ride.EndLocation,
                AdditionalInformations = ride.AdditionalInformations,
            };
        }

        public static SimpleRideDTO ToSimpleRideDTO(this Ride ride)
        {
            return new SimpleRideDTO
            {
                Id = ride.Id,
                RideEndedOn = ride.RideEndedOn,
                RideStartedOn = ride.RideStartedOn,
                VehicleID = ride.VehicleID,
                AppUserID = ride.AppUserID,
                StartLocation = ride.StartLocation,
                EndLocation = ride.EndLocation,
                AdditionalInformations = ride.AdditionalInformations,
                IsRideActive = ride.IsRideActive
            };
        }
    }
}