using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }


        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleService> VehicleServices { get; set; }

        public DbSet<Ride> Rides { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRides>(x => x.HasKey(p => new { p.RideId, p.AppUserId }));

            builder.Entity<UserRides>()
                .HasOne(u => u.AppUser)
                .WithMany(v => v.UserRides)
                .HasForeignKey(u => u.AppUserId);

            builder.Entity<UserRides>()
                .HasOne(u => u.Ride)
                .WithMany(v => v.UserRides)
                .HasForeignKey(u => u.RideId);

            builder.Entity<Ride>()
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.Rides)
                .HasForeignKey(e => e.VehicleID)
                .HasConstraintName("FK_Rides_Vehicles_VehicleId"); 

            builder.Entity<Ride>()
                .HasOne(e => e.AppUser)
                .WithMany(e => e.Rides)
                .HasForeignKey(e => e.AppUserID)
                .HasConstraintName("FK_Rides_AspNetUsers_AppUserId"); 


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole
                {
                    Name="User",
                    NormalizedName="USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}