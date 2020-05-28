using Application;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("medicalService/[controller]")]
    [ApiController]
    public class MedicalExamController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicalExamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("/{identification}")]
        public ActionResult<MedicalExam> Get(int identification)
        {
            var service = new SearchMedicalExamService(_unitOfWork);
            var response = service.Ejecute(new SearchMedicalExamRequest {Identification = identification});
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<RegisterMedicalExamResponse> Post(RegisterMedicalExamRequest request)
        {
            var service = new RegisterMedicalExamService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }

        [HttpPut("Complete")]
        public ActionResult<CompleteMedicalExamResponse> Post(CompleteMedicalExamRequest request)
        {
            var service = new CompleteMedicalExamService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }

        [HttpPut("Cancel")]
        public ActionResult<CancelMedicalExamResponse> Post(CancelMedicalExamRequest request)
        {
            var service = new CancelMedicalExamService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }

        [HttpPut("Postpone")]
        public ActionResult<PostponeMedicalExamResponse> Post(PostponeMedicalExamRequest request)
        {
            var service = new PostponeMedicalExamService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }
    }
}