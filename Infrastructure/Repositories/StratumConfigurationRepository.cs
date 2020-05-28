using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class StratumConfigurationRepository : GenericRepository<StratumConfiguration>,
        IStratumConfigurationRepository
    {
        public StratumConfigurationRepository(IDbContext context) : base(context)
        {
        }
    }
}