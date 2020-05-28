using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(IDbContext context) : base(context)
        {
        }
    }
}