using Application;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("medicalService/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        [HttpGet]
        public ActionResult<Doctor> GetAllDoctors()
        {
            var service = new SearchDoctorService(_unitOfWork);
            var response = service.Ejecute(new SearchDoctorRequest(){Identification = null});
            return Ok(response);
        }
        
        
        [HttpGet("{identification}")]
        public ActionResult<Doctor> GetSpecifyDoctor(string identification)
        {
            var service = new SearchDoctorService(_unitOfWork);
            var response = service.Ejecute(new SearchDoctorRequest(){Identification = identification});
            return Ok(response);
        }
        
        
        [HttpPost]
        public ActionResult<RegisterDoctorResponse> Post(RegisterDoctorRequest request)
        {
            var service = new RegisterDoctorService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }
    }
}