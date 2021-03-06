﻿using Domain.Contracts;

namespace Application
{
    public class CompleteMedicalExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteMedicalExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CompleteMedicalExamResponse Ejecute(CompleteMedicalExamRequest request)
        {
            var exam = _unitOfWork.MedicalExamRepository.FindFirstOrDefault(e => e.Id == request.Identification);
            if (exam != null)
            {
                exam.CompleteExam();
                _unitOfWork.Commit();
                return new CompleteMedicalExamResponse {Mensaje = "Examen completado Correctamente"};
            }

            return new CompleteMedicalExamResponse {Mensaje = "Error al completar el examen"};
        }
    }

    public class CompleteMedicalExamRequest
    {
        public int Identification { get; set; }
    }

    public class CompleteMedicalExamResponse
    {
        public string Mensaje { get; set; }
    }
}