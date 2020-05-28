using System;
using Domain.Contracts;

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
            if (medicalAppointment != null)
            {
                medicalAppointment.PostponeMedicalAppointment(request.Date, request.Hour);
                _unitOfWork.Commit();
                return new PostponeMedicalAppointmentResponse {Mensaje = "Cita medica aplazada satisfactoriamente"};
            }

            return new PostponeMedicalAppointmentResponse {Mensaje = "Error al aplazar la cita medica"};
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