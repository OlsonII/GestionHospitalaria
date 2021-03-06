﻿using Domain.Contracts;

namespace Application
{
    public class CancelMedicalAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelMedicalAppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CancelMedicalAppointmentResponse Ejecute(CancelMedicalAppointmentRequest request)
        {
            var medicalAppointment =
                _unitOfWork.MedicalAppointmentRepository.FindFirstOrDefault(m => m.Id == request.Identification);
            if (medicalAppointment != null)
            {
                medicalAppointment.CancelMedicalAppointment();
                _unitOfWork.Commit();
                return new CancelMedicalAppointmentResponse {Mensaje = "Cita medica cancelada satisfactoriamente"};
            }

            return new CancelMedicalAppointmentResponse {Mensaje = "Error al cancelar la cita medica"};
        }
    }

    public class CancelMedicalAppointmentRequest
    {
        public int Identification { get; set; }
    }

    public class CancelMedicalAppointmentResponse
    {
        public string Mensaje { get; set; }
    }
}