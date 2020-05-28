using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class CompleteMedicalAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteMedicalAppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CompleteMedicalAppointmentResponse Ejecute(CompleteMedicalAppointmentRequest request)
        {
            var medicalAppointment =
                _unitOfWork.MedicalAppointmentRepository.FindFirstOrDefault(m => m.Id == request.Identification);
            if (medicalAppointment != null)
            {
                medicalAppointment.CompleteMedicalAppointment(request.Prescription);
                _unitOfWork.Commit();
                return new CompleteMedicalAppointmentResponse {Mensaje = "Cita medica completada satisfactoriamente"};
            }

            return new CompleteMedicalAppointmentResponse {Mensaje = "Error al completar la cita medica"};
        }
    }

    public class CompleteMedicalAppointmentRequest
    {
        public int Identification { get; set; }
        public Prescription Prescription { get; set; }
    }

    public class CompleteMedicalAppointmentResponse
    {
        public string Mensaje { get; set; }
    }
}