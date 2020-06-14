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
            var medicalAppointment =
                _unitOfWork.MedicalAppointmentRepository.FindFirstOrDefault(m => m.Id == request.Identification);

            var turn = CalculateTurn(request);

            if (medicalAppointment == null)
            {
                newMedicalAppointment = new MedicalAppointment();
                newMedicalAppointment.Doctor = new SearchDoctorService(_unitOfWork)
                    .Ejecute(new SearchDoctorRequest {Identification = request.Doctor.Id}).Doctor; //request.Doctor
                newMedicalAppointment.Patient =new SearchPatientService(_unitOfWork)
                    .Ejecute(new SearchPatientRequest{Identification = request.Patient.Id}).Patient; //request.Patient
                newMedicalAppointment.Date = request.Date;
                newMedicalAppointment.Time = newMedicalAppointment.Doctor.Workday;
                newMedicalAppointment.Turn = turn;
                newMedicalAppointment.Prescription = null;
                newMedicalAppointment.State = "Programada";
                newMedicalAppointment.GenerateCost();
                _unitOfWork.MedicalAppointmentRepository.Add(newMedicalAppointment);
                _unitOfWork.Commit();
                return new RegisterMedicalAppointmentResponse {Mensaje = "Cita medica creada satisfactoriamente", Turno = turn};
            }

            return new RegisterMedicalAppointmentResponse {Mensaje = "Error al crear la cita medica", Turno = turn};
        }
        
        private int CalculateTurn(RegisterMedicalAppointmentRequest request)
        {
            var turn = 0;
            var medicalAppointments = 
                _unitOfWork.MedicalAppointmentRepository.FindBy(m => m.Date == request.Date && m.Doctor == request.Doctor && m.State == "Programada");
            
            foreach (var appointment in medicalAppointments)
            {
                turn++;
            }

            if (turn == 0)
                turn++;

            return turn;
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
        public int Turno { get; set; }
    }
}