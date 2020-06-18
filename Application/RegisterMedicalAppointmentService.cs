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
            
            if(!ValidatePatient(request.Patient))
                return new RegisterMedicalAppointmentResponse {Mensaje = "Este paciente ya tiene una cita medica programada"};
            
            if(!ValidateDate(DateTime.Now, request.Date))
                return new RegisterMedicalAppointmentResponse {Mensaje = "Por favor, ingrese una fecha valida"};
                
            if(!ValidateTurn(turn))
                return new RegisterMedicalAppointmentResponse {Mensaje = "Ya no hay mas cupos para esta jornada"};
            
            if (medicalAppointment == null)
            {
                newMedicalAppointment = new MedicalAppointment();
                newMedicalAppointment.Doctor = /*new SearchDoctorService(_unitOfWork)
                    .Ejecute(new SearchDoctorRequest {Identification = request.Doctor.Id}).Doctor; //*/request.Doctor;
                newMedicalAppointment.Patient =/*new SearchPatientService(_unitOfWork)
                    .Ejecute(new SearchPatientRequest{Identification = request.Patient.Id}).Patient; //*/request.Patient;
                newMedicalAppointment.Date = request.Date;
                newMedicalAppointment.Time = newMedicalAppointment.Doctor.Workday;
                newMedicalAppointment.Turn = turn;
                newMedicalAppointment.Prescription = null;
                newMedicalAppointment.GenerateCost();
                _unitOfWork.MedicalAppointmentRepository.Add(newMedicalAppointment);
                _unitOfWork.Commit();
                return new RegisterMedicalAppointmentResponse {Mensaje = "Cita medica creada satisfactoriamente", Turno = turn};
            }

            return new RegisterMedicalAppointmentResponse {Mensaje = "Error al crear la cita medica"};
        }
        
        public bool ValidateDate(DateTime oldDate, DateTime newDate)
        {
            if (oldDate.CompareTo(newDate) == 1)
                return false;
            
            return true;
        }

        public bool ValidatePatient(Patient patient)
        {
            var medicalAppointmentByPatient = _unitOfWork.MedicalAppointmentRepository.FindBy(m => m.Patient == patient);

            foreach (var m in medicalAppointmentByPatient)
            {
                if (m.State.Equals("Programada"))
                    return false;
            }
            
            return true;
        }
        
        private int CalculateTurn(RegisterMedicalAppointmentRequest request)
        {
            var turn = 0;
            var medicalAppointments = 
                _unitOfWork.MedicalAppointmentRepository.FindBy(m => m.Date == request.Date && m.Doctor == request.Doctor);
            
            foreach (var appointment in medicalAppointments)
            {
                if(appointment.State.Equals("Programada") || appointment.State.Equals("Aplazada"))
                    turn++;
            }

            if (turn == 0)
            {
                return 1;
            }

            return turn+1;
        }

        private bool ValidateTurn(int turn)
        {
            if (turn <= 20)
                return true;

            return false;
        }
    }

    public class RegisterMedicalAppointmentRequest
    {
        public int Identification { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
    }

    public class RegisterMedicalAppointmentResponse
    {
        public string Mensaje { get; set; }
        public int Turno { get; set; }
    }
}