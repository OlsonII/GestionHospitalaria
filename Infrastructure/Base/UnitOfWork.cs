using Domain.Contracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;
        private IDoctorRepository _doctorRepository;
        private IMedicalAppointmentRepository _medicalAppointmentRepository;
        private IMedicalExamRepository _medicalExamRepository;
        private IPatientRepository _patientRepository;
        private IStratumConfigurationRepository _stratumConfigurationRepository;
        private IWorkdayConfigurationRepository _workdayConfigurationRepository;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IStratumConfigurationRepository StratumConfigurationRepository =>
            _stratumConfigurationRepository ??
            (_stratumConfigurationRepository = new StratumConfigurationRepository(_dbContext));

        public IWorkdayConfigurationRepository WorkdayConfigurationRepository =>
            _workdayConfigurationRepository ??
            (_workdayConfigurationRepository = new WorkdayConfigurationRepository(_dbContext));

        public IMedicalAppointmentRepository MedicalAppointmentRepository =>
            _medicalAppointmentRepository ??
            (_medicalAppointmentRepository = new MedicalAppointmentRepository(_dbContext));

        public IMedicalExamRepository MedicalExamRepository =>
            _medicalExamRepository ??
            (_medicalExamRepository = new MedicalExamRepository(_dbContext));

        public IDoctorRepository DoctorRepository =>
            _doctorRepository ??
            (_doctorRepository = new DoctorRepository(_dbContext));

        public IPatientRepository PatientRepository =>
            _patientRepository ??
            (_patientRepository = new PatientRepository(_dbContext));

        public void Dispose()
        {
            Dispose(true);
        }


        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext) _dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}