using System;
using Domain.Repositories;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IMedicalAppointmentRepository MedicalAppointmentRepository { get; }
        IMedicalExamRepository MedicalExamRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IPatientRepository PatientRepository { get; }
        IStratumConfigurationRepository StratumConfigurationRepository { get; }

        int Commit();
    }
}