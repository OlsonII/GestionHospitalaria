using Domain.Contracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;
        private IMedicalAppointmentRepository _medicalAppointmentRepository;
        private IMedicalExamRepository _medicalExamRepository;
        private IDoctorRepository _doctorRepository;
        private IPatientRepository _patientRepository;
        private IStratumConfigurationRepository _stratumConfigurationRepository;
        private IWorkdayConfigurationRepository _workdayConfigurationRepository;
        
        public IStratumConfigurationRepository StratumConfigurationRepository
        {
            get
            {
                return _stratumConfigurationRepository ??
                       (_stratumConfigurationRepository = new StratumConfigurationRepository(_dbContext));
            }
        }
        
        public IWorkdayConfigurationRepository WorkdayConfigurationRepository
        {
            get
            {
                return _workdayConfigurationRepository ??
                       (_workdayConfigurationRepository = new WorkdayConfigurationRepository(_dbContext));
            }
        }
        
        public IMedicalAppointmentRepository MedicalAppointmentRepository
        {
            get
            {
                return _medicalAppointmentRepository ??
                       (_medicalAppointmentRepository = new MedicalAppointmentRepository(_dbContext));
            }
        }

        public IMedicalExamRepository MedicalExamRepository
        {
            get
            {
                return _medicalExamRepository ??
                       (_medicalExamRepository = new MedicalExamRepository(_dbContext));
            }
        }
        
        public IDoctorRepository DoctorRepository
        {
            get
            {
                return _doctorRepository ??
                       (_doctorRepository = new DoctorRepository(_dbContext));
            }
        }
        
        public IPatientRepository PatientRepository
        {
            get
            {
                return _patientRepository ??
                       (_patientRepository = new PatientRepository(_dbContext));
            }
        }

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }

        
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}