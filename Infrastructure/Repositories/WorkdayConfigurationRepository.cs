using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class WorkdayConfigurationRepository : GenericRepository<WorkdayConfiguration>, IWorkdayConfigurationRepository
    {
        public WorkdayConfigurationRepository(IDbContext context) : base(context)
        {
        }
    }
}