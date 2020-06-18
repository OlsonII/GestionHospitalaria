using System;
using Domain.Contracts;

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
            var exam = _unitOfWork.MedicalExamRepository.FindFirstOrDefault(e => e.Id == request.Identification);
            
            if(!ValidateDate(exam.Date, request.Date))
                return new PostponeMedicalExamResponse {Mensaje = "Por favor ingrese una fecha posterior a la actual"};
            
            if (exam != null)
            {
                exam.CancelExam();
                _unitOfWork.Commit();
                return new PostponeMedicalExamResponse {Mensaje = "Examen aplazado Correctamente"};
            }

            return new PostponeMedicalExamResponse {Mensaje = "Error al aplazar el examen"};
        }
        
        public bool ValidateDate(DateTime oldDate, DateTime newDate)
        {
            if (oldDate.CompareTo(newDate) == 1)
                return false;
            
            return true;
        }
    }

    public class PostponeMedicalExamRequest
    {
        public int Identification { get; set; }
        public DateTime Date { get; set; }
    }

    public class PostponeMedicalExamResponse
    {
        public string Mensaje { get; set; }
    }
}