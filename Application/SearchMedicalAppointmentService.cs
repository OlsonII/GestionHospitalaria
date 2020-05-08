using System.Collections.Generic;
using System.Linq;
using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class SearchMedicalAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchMedicalAppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SearchMedicalAppointmentResponse Ejecute(SearchMedicalAppointmentRequest request)
        {
            List<MedicalAppointment> medicalAppointment;
            if (request.PatientIdentification != null)
            {
                medicalAppointment =
                    _unitOfWork.MedicalAppointmentRepository.
                        FindBy(m => m.Patient.Identification == request.PatientIdentification).ToList();
            }
            else
            {
                medicalAppointment =
                    _unitOfWork.MedicalAppointmentRepository.
                        FindBy(m => m.Doctor.Identification == request.DoctorIdentification).ToList();
            }
            foreach (var m in medicalAppointment)
            {
                m.Patient = new SearchPatientService(_unitOfWork).Ejecute(new SearchPatientRequest(){Identification = request.PatientIdentification}).Patient;
                m.Doctor = new SearchDoctorService(_unitOfWork).Ejecute(new SearchDoctorRequest(){Identification = request.DoctorIdentification}).Doctor;
            }
            return new SearchMedicalAppointmentResponse(){MedicalAppointment = medicalAppointment};
        }
    }

    public class SearchMedicalAppointmentRequest
    {
        public string PatientIdentification { get; set; }
        public string DoctorIdentification { get; set; }
    }

    public class SearchMedicalAppointmentResponse
    {
        public List<MedicalAppointment> MedicalAppointment { get; set; }
    }
}