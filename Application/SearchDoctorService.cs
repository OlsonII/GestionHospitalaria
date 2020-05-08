using System.Collections.Generic;
using System.Linq;
using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class SearchDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchDoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SearchDoctorResponse Ejecute(SearchDoctorRequest request)
        {
            if (request.Identification != null)
            {
                Doctor doctor =
                    _unitOfWork.DoctorRepository.FindFirstOrDefault(d => d.Id == request.Identification);
                return new SearchDoctorResponse(){Doctor = doctor};
            }
            
            return new SearchDoctorResponse(){Doctors = _unitOfWork.DoctorRepository.GetAll().ToList()};
        }
        
    }

    public class SearchDoctorRequest
    {
        public string Identification { get; set; }
    }

    public class SearchDoctorResponse
    {
        public Doctor Doctor { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}