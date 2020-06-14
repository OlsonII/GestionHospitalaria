using System;
using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class RegisterMedicalExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterMedicalExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegisterMedicalExamResponse Ejecute(RegisterMedicalExamRequest request)
        {
            var turn = CalculateTurn(request);
            
            MedicalExam newExam = null;
            var exam = _unitOfWork.MedicalExamRepository.FindFirstOrDefault(e => e.Id == request.Identification);
            if (exam == null)
            {
                newExam = new MedicalExam();
                // newExam.Identification = request.Identification;
                newExam.Name = request.Name;
                newExam.Patient = request.Patient;
                newExam.Date = request.Date;
                newExam.Turn = turn;
                newExam.Time = "Mañana";
                newExam.State = "Programado";
                newExam.GenerateCost();
                _unitOfWork.MedicalExamRepository.Add(newExam);
                _unitOfWork.Commit();
                return new RegisterMedicalExamResponse {Mensaje = "Examen medico creado satisfactoriamente"};
            }
            
            

            return new RegisterMedicalExamResponse {Mensaje = "Error al registrar el examen medico"};
        }
        
        private int CalculateTurn(RegisterMedicalExamRequest request)
        {
            var turn = 0;
            var medicalAppointments = 
                _unitOfWork.MedicalAppointmentRepository.FindBy(m => m.Date == request.Date && m.State == "Programado");
            
            foreach (var appointment in medicalAppointments)
            {
                turn++;
            }

            return turn;
        }
    }

    public class RegisterMedicalExamRequest
    {
        public int Identification { get; set; }
        public string Name { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
    }

    public class RegisterMedicalExamResponse
    {
        public string Mensaje { get; set; }
    }
}