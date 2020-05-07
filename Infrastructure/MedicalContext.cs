using System;
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
    }
}