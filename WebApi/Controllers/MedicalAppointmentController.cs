using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("medicalService/[controller]")]
    [ApiController]
    public class MedicalAppointmentController : ControllerBase
    {
        
        readonly IUnitOfWork _unitOfWork;

        public MedicalAppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Ok");
        }
        
        [HttpGet("patient/{identification}")]
        public ActionResult<List<MedicalAppointment>> GetByPatient(string identification)
        {
            var service = new SearchMedicalAppointmentService(_unitOfWork);
            var response = service.Ejecute(new SearchMedicalAppointmentRequest(){PatientIdentification = identification});
            return Ok(response);
        }
        
        [HttpGet("doctor/{identification}")]
        public ActionResult<MedicalAppointment> GetByDoctor(string identification)
        {
            var service = new SearchMedicalAppointmentService(_unitOfWork);
            var response = service.Ejecute(new SearchMedicalAppointmentRequest(){DoctorIdentification = identification});
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<RegisterMedicalAppointmentResponse> Post(RegisterMedicalAppointmentRequest request)
        {
            var service = new RegisterMedicalAppointmentService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }
        
        [HttpPut("Complete")]
        public ActionResult<CompleteMedicalAppointmentResponse> PutComplete(CompleteMedicalAppointmentRequest request)
        {
            var service = new CompleteMedicalAppointmentService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }
        
        [HttpPut("Cancel")]
        public ActionResult<CancelMedicalAppointmentResponse> PutCancel(CancelMedicalAppointmentRequest request)
        {
            var service = new CancelMedicalAppointmentService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }
        
        [HttpPut("Postpone")]
        public ActionResult<PostponeMedicalAppointmentResponse> PutPostpone(PostponeMedicalAppointmentRequest request)
        {
            var service = new PostponeMedicalAppointmentService(_unitOfWork);
            var response = service.Ejecute(request);
            return Ok(response);
        }
    }
}