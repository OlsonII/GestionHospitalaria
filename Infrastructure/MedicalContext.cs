using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MedicalContext : DbContextBase
    {
        public MedicalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        public DbSet<MedicalExam> MedicalExams { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<StratumConfiguration> StratumConfigurations { get; set; }
    }
}