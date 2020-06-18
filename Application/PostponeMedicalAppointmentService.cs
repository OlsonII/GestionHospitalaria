using System;
using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class PostponeMedicalAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostponeMedicalAppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PostponeMedicalAppointmentResponse Ejecute(PostponeMedicalAppointmentRequest request)
        {
            var medicalAppointment =
                _unitOfWork.MedicalAppointmentRepository.FindFirstOrDefault(m => m.Id == request.Identification);

            var turn = CalculateTurn(request, medicalAppointment);
            
            if(!ValidateDate(medicalAppointment.Date, request.Date))
                return new PostponeMedicalAppointmentResponse {Mensaje = "Por favor ingrese una fecha posterior a la actual"};

            if (medicalAppointment != null)
            {
                medicalAppointment.PostponeMedicalAppointment(request.Date, turn);
                _unitOfWork.Commit();
                return new PostponeMedicalAppointmentResponse {Mensaje = "Cita medica aplazada satisfactoriamente"};
            }

            return new PostponeMedicalAppointmentResponse {Mensaje = "Error al aplazar la cita medica"};
        }

        public bool ValidateDate(DateTime oldDate, DateTime newDate)
        {
            if (oldDate.CompareTo(newDate) == 1)
                return false;
            
            return true;
        }

        private int CalculateTurn(PostponeMedicalAppointmentRequest request, MedicalAppointment medicalAppointment)
        {
            var turn = 0;
            var medicalAppointments = 
                _unitOfWork.MedicalAppointmentRepository.FindBy(m => m.Date == request.Date && m.Doctor == medicalAppointment.Doctor && m.State == "Programada");
            
            foreach (var appointment in medicalAppointments)
            {
                if(appointment.State == "Programada" || appointment.State == "Aplazada")
                    turn++;
            }

            return turn;
        }
    }

    public class PostponeMedicalAppointmentRequest
    {
        public int Identification { get; set; }
        public DateTime Date { get; set; }
    }

    public class PostponeMedicalAppointmentResponse
    {
        public string Mensaje { get; set; }
    }
}