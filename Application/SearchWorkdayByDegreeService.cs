using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class SearchWorkdayByDegreeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchWorkdayByDegreeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SearchWorkdayByDegreeResponse Ejecute(SearchWorkdayByDegreeRequest request)
        {
            var workday = _unitOfWork.WorkdayConfigurationRepository.FindFirstOrDefault(s => s.Id == 1);

            return new SearchWorkdayByDegreeResponse {Workday = SelectWorkday(request, workday)};
        }

        private string SelectWorkday(SearchWorkdayByDegreeRequest request, WorkdayConfiguration workday)
        {
            var newWorkday = "";
            switch (request.Degree)
            {
                case "Medico":
                    newWorkday = workday.DoctorWorkday;
                    break;
                case "Pediatra":
                    newWorkday = workday.PediatricianWorkday;
                    break;
                case "Oftalmologo":
                    newWorkday = workday.OphthalmologistWorkday;
                    break;
                case "Odontologo":
                    newWorkday = workday.DentistWorkday;
                    break;
            }

            return newWorkday;
        }
    }

    public class SearchWorkdayByDegreeRequest
    {
        public string Degree { get; set; }
    }

    public class SearchWorkdayByDegreeResponse
    {
        public string Workday { get; set; }
    }
}