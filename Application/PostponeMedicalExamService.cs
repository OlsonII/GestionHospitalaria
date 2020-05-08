using Domain.Contracts;
using Domain.Entities;
using System;

namespace Application
{
    public class PostponeMedicalExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostponeMedicalExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PostponeMedicalExamResponse Ejecute(PostponeMedicalExamRequest request)
        {
            MedicalExam exam = _unitOfWork.MedicalExamRepository.FindFirstOrDefault(e => e.Code == request.Code);
            if (exam != null)
            {
                exam.CancelExam();
                _unitOfWork.Commit();
                return new PostponeMedicalExamResponse(){Mensaje = $"Examen aplazado Correctamente"};
            }
            
            return new PostponeMedicalExamResponse(){Mensaje = $"Error al aplazar el examen"};
        }
        
    }

    public class PostponeMedicalExamRequest
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
    }
    
    public class PostponeMedicalExamResponse
    {
        public string Mensaje { get; set; }
    }
}