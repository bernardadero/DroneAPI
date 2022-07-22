using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DroneAPI.Models;

namespace DroneAPI.Database
{
    public class DroneAPIContext : DbContext
    {
        public DroneAPIContext()
        {
        }

        public DroneAPIContext (DbContextOptions<DroneAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Drone>? Drone { get; set; }

        public DbSet<LoadedMedicineModel>? LoadedMedicineModel { get; set; }

        public DbSet<MedicationModel>? MedicationModel { get; set; }
        public DbSet<BatteryLeveModel>? BatteryLeveModel { get; set; }
    }
}
