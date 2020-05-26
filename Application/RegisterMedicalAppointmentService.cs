using System;
using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class RegisterMedicalAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterMedicalAppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegisterMedicalAppointmentResponse Ejecute(RegisterMedicalAppointmentRequest request)
        {
            MedicalAppointment newMedicalAppointment = null;

            MedicalAppointment medicalAppointment = 
                _unitOfWork.MedicalAppointmentRepository.FindFirstOrDefault(m => m.Id == request.Identification);
            
            if (medicalAppointment == null)
            {
                newMedicalAppointment = new MedicalAppointment();
                newMedicalAppointment.Doctor = new SearchDoctorService(_unitOfWork).Ejecute(new SearchDoctorRequest{Identification = request.Doctor.Id}).Doctor;
                newMedicalAppointment.Patient = request.Patient; //new SearchPatientService(_unitOfWork).Ejecute(new SearchPatientRequest{Identification = request.Patient.Id}).Patient;
                newMedicalAppointment.Date = request.Date;
                newMedicalAppointment.Hour = request.Hour;
                newMedicalAppointment.Prescription = null;
                newMedicalAppointment.State = "Programada";
                newMedicalAppointment.GenerateCost();
                _unitOfWork.MedicalAppointmentRepository.Add(newMedicalAppointment);
                _unitOfWork.Commit();
                return new RegisterMedicalAppointmentResponse() {Mensaje = "Cita medica creada satisfactoriamente"};
            }
            else
            {
                return new RegisterMedicalAppointmentResponse() {Mensaje = "Error al crear la cita medica"};
            }
        }
    }

    public class RegisterMedicalAppointmentRequest
    {
        public int Identification { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime Hour { get; set; }
        public DateTime Date { get; set; }
    }
    
    public class RegisterMedicalAppointmentResponse
    {
        public string Mensaje { get; set; }
    }
}