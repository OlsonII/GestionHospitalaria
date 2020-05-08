using System.Collections.Generic;
using System.Linq;
using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class SearchPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchPatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SearchPatientResponse Ejecute(SearchPatientRequest request)
        {
            if (request.Identification != null)
            {
                Patient patient =
                    _unitOfWork.PatientRepository.FindFirstOrDefault(p => p.Identification == request.Identification);
                return new SearchPatientResponse(){Patient = patient};
            }
            
            return new SearchPatientResponse(){Patients = _unitOfWork.PatientRepository.GetAll().ToList()};
        }
    }

    public class SearchPatientRequest
    {
        public string Identification { get; set; }
    }

    public class SearchPatientResponse
    {
        public Patient Patient { get; set; }
        public List<Patient> Patients { get; set; }
    }
}