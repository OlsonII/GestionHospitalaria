using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class MedicalExamRepository : GenericRepository<MedicalExam>, IMedicalExamRepository
    {
        public MedicalExamRepository(IDbContext context) : base(context)
        {
        }
    }
}