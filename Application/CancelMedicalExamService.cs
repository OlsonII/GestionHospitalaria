using Domain.Contracts;

namespace Application
{
    public class CancelMedicalExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelMedicalExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CancelMedicalExamResponse Ejecute(CancelMedicalExamRequest request)
        {
            var exam = _unitOfWork.MedicalExamRepository.FindFirstOrDefault(e => e.Id == request.Identification);
            if (exam != null)
            {
                exam.CancelExam();
                _unitOfWork.Commit();
                return new CancelMedicalExamResponse {Mensaje = "Examen cancelado Correctamente"};
            }

            return new CancelMedicalExamResponse {Mensaje = "Error al cancelar el examen"};
        }
    }

    public class CancelMedicalExamRequest
    {
        public int Identification { get; set; }
    }

    public class CancelMedicalExamResponse
    {
        public string Mensaje { get; set; }
    }
}