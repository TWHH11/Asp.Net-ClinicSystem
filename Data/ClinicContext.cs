using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicInfo.Models;

namespace ClinicInfo.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext (DbContextOptions<ClinicContext> options)
            : base(options)
        {
        }

        public DbSet<ClinicInfo.Models.Patient> Patient { get; set; } = default!;

        public DbSet<ClinicInfo.Models.Doctor> Doctor { get; set; } = default!;

        public DbSet<ClinicInfo.Models.DoctorVisit> DoctorVisit { get; set; } = default!;

        public DbSet<ClinicInfo.Models.Booking> Booking { get; set; } = default!;


        
    }
}
