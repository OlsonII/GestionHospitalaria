using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class SearchMedicalExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchMedicalExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SearchMedicalExamResponse Ejecute(SearchMedicalExamRequest request)
        {
            MedicalExam medicalExam = _unitOfWork.MedicalExamRepository.FindFirstOrDefault(m => m.Identification == request.Identification);
            return new SearchMedicalExamResponse(){MedicalExam = medicalExam};
        }
    }

    public class SearchMedicalExamRequest
    {
        public int Identification { get; set; }
    }

    public class SearchMedicalExamResponse
    {
        public MedicalExam MedicalExam { get; set; }
    }
}