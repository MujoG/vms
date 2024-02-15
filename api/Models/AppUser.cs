using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public List<UserRides> UserRides { get; set; } = new List<UserRides>();
        public List<Ride> Rides { get; set; } = new List<Ride>();

    }
}