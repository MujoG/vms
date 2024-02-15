using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Rides;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RideRepository : IRideRepository
    {
        private readonly ApplicationDBContext _context;

        public RideRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Ride?> CreateNewRide(Ride ride)
        {
            await _context.AddAsync(ride);
            await _context.SaveChangesAsync();

            return ride;
        }

        public async Task<Ride?> DeleteRide(int id)
        {
            var modelDeleteRide = await _context.Rides.FindAsync(id);

            if (modelDeleteRide == null)
            {
                return null;
            }

            _context.Rides.Remove(modelDeleteRide);

            await _context.SaveChangesAsync();

            return modelDeleteRide;
        }

        public async Task<List<Ride>> GetAllRides()
        {
            var rides = await _context.Rides.Include(v => v.Vehicle).Include(u => u.AppUser).ToListAsync();

            return rides;
        }

        public async Task<Ride?> GetRideById(int id)
        {
            var rideById = await _context.Rides.FirstOrDefaultAsync(r => r.Id == id);

            return rideById;
        }

        public async Task<Ride?> UpdateRide(int Id, Ride ride)
        {
            var rideexist = await _context.Rides.FirstOrDefaultAsync(r => r.Id == Id);

            if (rideexist == null)
            {
                return null;
            }

            rideexist.Id = rideexist.Id;
            rideexist.VehicleID = ride.VehicleID;
            rideexist.RideEndedOn = ride.RideEndedOn;
            rideexist.RideStartedOn = ride.RideStartedOn;
            rideexist.AppUserID = ride.AppUserID;
            rideexist.AdditionalInformations = ride.AdditionalInformations;
            rideexist.StartLocation = ride.StartLocation;
            rideexist.EndLocation = ride.EndLocation;
            rideexist.IsRideActive = ride.IsRideActive;

            rideexist.Vehicle = ride.Vehicle;
            rideexist.AppUser = ride.AppUser;


            await _context.SaveChangesAsync();

            return rideexist;
        }
    }
}