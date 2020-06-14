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

            if (medicalAppointment != null)
            {
                medicalAppointment.PostponeMedicalAppointment(request.Date, turn);
                _unitOfWork.Commit();
                return new PostponeMedicalAppointmentResponse {Mensaje = "Cita medica aplazada satisfactoriamente"};
            }

            return new PostponeMedicalAppointmentResponse {Mensaje = "Error al aplazar la cita medica"};
        }

        private int CalculateTurn(PostponeMedicalAppointmentRequest request, MedicalAppointment medicalAppointment)
        {
            var turn = 0;
            var medicalAppointments = 
                _unitOfWork.MedicalAppointmentRepository.FindBy(m => m.Date == request.Date && m.Doctor == medicalAppointment.Doctor && m.State == "Programada");
            
            foreach (var appointment in medicalAppointments)
            {
                turn++;
            }

            return turn;
        }
    }

    public class PostponeMedicalAppointmentRequest
    {
        public int Identification { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
    }

    public class PostponeMedicalAppointmentResponse
    {
        public string Mensaje { get; set; }
    }
}