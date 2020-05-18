using System;
using Application;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ApplicationTest
{
    public class MedicalAppointmentTests
    {
        private MedicalContext _context;
        
        [SetUp]
        public void Setup()
        {
            var optionsInDb = new DbContextOptionsBuilder<MedicalContext>()
                .UseSqlServer("Server=DESKTOP-N95GP02\\SQLEXPRESS;Database=MedicalServices;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            
            _context = new MedicalContext(optionsInDb);
        }

        [Test]
        public void RegisterMedicalAppointmentDoctorTest()
        {
            var request = new RegisterMedicalAppointmentRequest{Doctor = new Doctor{Id = "1065"}, Patient = new Patient{Id = "1066"}, Date = DateTime.Now, Hour = DateTime.Now.Date};
            var service = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica creada satisfactoriamente", response.Mensaje);
        }
        
        [Test]
        public void RegisterMedicalAppointmentPediatricianTest()
        {
            var request = new RegisterMedicalAppointmentRequest{Doctor = new Doctor{Id = "2222"}, Patient = new Patient{Id = "1066"}, Date = DateTime.Now, Hour = DateTime.Now.Date};
            var service = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica creada satisfactoriamente", response.Mensaje);
        }
        
        [Test]
        public void RegisterMedicalAppointmentDentistTest()
        {
            var request = new RegisterMedicalAppointmentRequest{Doctor = new Doctor{Id = "3333"}, Patient = new Patient{Id = "1067"}, Date = DateTime.Now, Hour = DateTime.Now.Date};
            var service = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica creada satisfactoriamente", response.Mensaje);
        }
        
        [Test]
        public void RegisterMedicalAppointmentOphthalmologistTest()
        {
            var request = new RegisterMedicalAppointmentRequest{Doctor = new Doctor{Id = "4444"}, Patient = new Patient{Id = "9999"}, Date = DateTime.Now, Hour = DateTime.Now.Date};
            var service = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica creada satisfactoriamente", response.Mensaje);
        }
        
        [Test]
        public void CompleteMedicalAppointmentTest()
        {
            var request = new CompleteMedicalAppointmentRequest(){Identification = 19};
            var service = new CompleteMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica completada satisfactoriamente", response.Mensaje);
        }
        
        [Test]
        public void PostponeMedicalAppointmentTest()
        {
            var request = new PostponeMedicalAppointmentRequest(){Identification = 20, Date = DateTime.Now.AddDays(3), Hour = DateTime.Now.Date.AddHours(14)};
            var service = new PostponeMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica aplazada satisfactoriamente", response.Mensaje);
        }
        
        [Test]
        public void CancelMedicalAppointmentTest()
        {
            var request = new CancelMedicalAppointmentRequest(){Identification = 21};
            var service = new CancelMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica cancelada satisfactoriamente", response.Mensaje);
        }
    }
}