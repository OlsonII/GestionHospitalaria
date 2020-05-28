using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class RegisterWorkdayByDegreeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterWorkdayByDegreeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegisterWorkdayByDegreeResponse Ejecute(RegisterWorkdayByDegreeRequest request)
        {
            var workday = new WorkdayConfiguration();
            workday.DentistWorkday = request.DentistWorkday;
            workday.DoctorWorkday = request.DoctorWorkday;
            workday.OphthalmologistWorkday = request.OphthalmologistWorkday;
            workday.PediatricianWorkday = request.PediatricianWorkday;
            _unitOfWork.WorkdayConfigurationRepository.Add(workday);
            _unitOfWork.Commit();
            return new RegisterWorkdayByDegreeResponse {Message = "Correcto"};
        }
    }

    public class RegisterWorkdayByDegreeRequest
    {
        public string DoctorWorkday { get; set; }
        public string PediatricianWorkday { get; set; }
        public string OphthalmologistWorkday { get; set; }
        public string DentistWorkday { get; set; }
    }

    public class RegisterWorkdayByDegreeResponse
    {
        public string Message { get; set; }
    }
}