using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public override IEnumerable<MedicalAppointment> FindBy(Expression<Func<MedicalAppointment, bool>> predicate)
        {
            //TODO: IMPLEMENTAR INCLUDES PARA CARGA EXPLICITA AQUI
            return base.FindBy(predicate);
        }
    }
}