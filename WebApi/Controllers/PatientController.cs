using Application;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("medicalService/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public ActionResult<Patient> GetAllPatients()
        {
            var service = new SearchPatientService(_unitOfWork);
            var response = service.Ejecute(new SearchPatientRequest(){Identification = null});
            return Ok(response);
        }
        
        [HttpGet("{identification}")]
        public ActionResult<Doctor> GetSpecifyPatient(string identification)
        {
            var service = new SearchPatientService(_unitOfWork);
            var response = service.Ejecute(new SearchPatientRequest(){Identification = identification});
            return Ok(response);
        }
        
        [HttpPost]
        public ActionResult<RegisterPatientResponse> Post(RegisterPatientRequest request)
        {
            var service = new RegisterPatientService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }
    }
}