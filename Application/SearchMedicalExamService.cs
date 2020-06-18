using System.Collections.Generic;
using System.Linq;
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
            if (request.Identification == 0)
            {
                var medicalExam = _unitOfWork.MedicalExamRepository.FindBy(includeProperties: "Patient").ToList();
                return new SearchMedicalExamResponse {MedicalExams = medicalExam};
            }
            else
            {
                var medicalExam = _unitOfWork.MedicalExamRepository.FindBy(m => m.Id == request.Identification).ToList();
                return new SearchMedicalExamResponse {MedicalExams = medicalExam};
            }
            
            
        }
    }

    public class SearchMedicalExamRequest
    {
        public int Identification { get; set; }
    }

    public class SearchMedicalExamResponse
    {
        public List<MedicalExam> MedicalExams { get; set; }
    }
}