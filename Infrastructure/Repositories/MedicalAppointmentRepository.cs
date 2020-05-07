using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class MedicalAppointmentRepository : GenericRepository<MedicalAppointment>, IMedicalAppointmentRepository
    {
        public MedicalAppointmentRepository(IDbContext context) : base(context)
        {
            
        }
    }
}