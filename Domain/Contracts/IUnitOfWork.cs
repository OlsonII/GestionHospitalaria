using System;
using Domain.Repositories;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IMedicalAppointmentRepository MedicalAppointmentRepository { get; }
        
        int Commit();
    }
}