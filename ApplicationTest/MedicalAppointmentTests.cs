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
            /*var optionsInDb = new DbContextOptionsBuilder<MedicalContext>()
                .UseSqlServer("Server=DESKTOP-N95GP02\\SQLEXPRESS;Database=MedicalServices;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            
            _context = new MedicalContext(optionsInDb);*/

            var optionsInMemory = new DbContextOptionsBuilder<MedicalContext>().UseInMemoryDatabase("MedicalServices")
                .Options;

            _context = new MedicalContext(optionsInMemory);

            _context.Database.EnsureDeleted();
        }

        [Test]
        public void RegisterMedicalAppointmentDoctorTest()
        {
            var request = new RegisterMedicalAppointmentRequest
            {
                Doctor = new Doctor {Id = "1111"}, Patient = new Patient {Id = "1001", Stratum = 1},
                Date = DateTime.Now, Hour = DateTime.Now.Date
            };
            var service = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica creada satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void RegisterMedicalAppointmentPediatricianTest()
        {
            var request = new RegisterMedicalAppointmentRequest
            {
                Doctor = new Doctor {Id = "2222"}, Patient = new Patient {Id = "1002", Stratum = 1},
                Date = DateTime.Now, Hour = DateTime.Now.Date
            };
            var service = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica creada satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void RegisterMedicalAppointmentDentistTest()
        {
            var request = new RegisterMedicalAppointmentRequest
            {
                Doctor = new Doctor {Id = "3333"}, Patient = new Patient {Id = "1003", Stratum = 2},
                Date = DateTime.Now, Hour = DateTime.Now.Date
            };
            var service = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica creada satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void RegisterMedicalAppointmentOphthalmologistTest()
        {
            var request = new RegisterMedicalAppointmentRequest
            {
                Doctor = new Doctor {Id = "4444"}, Patient = new Patient {Id = "1004", Stratum = 4},
                Date = DateTime.Now, Hour = DateTime.Now.Date
            };
            var service = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica creada satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void CompleteMedicalAppointmentTest()
        {
            var requestA = new RegisterMedicalAppointmentRequest
            {
                Doctor = new Doctor {Id = "4444"}, Patient = new Patient {Id = "1004", Stratum = 4},
                Date = DateTime.Now, Hour = DateTime.Now.Date
            };
            var serviceA = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            serviceA.Ejecute(requestA);

            var request = new CompleteMedicalAppointmentRequest {Identification = 1};
            var service = new CompleteMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica completada satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void PostponeMedicalAppointmentTest()
        {
            var requestA = new RegisterMedicalAppointmentRequest
            {
                Doctor = new Doctor {Id = "4444"}, Patient = new Patient {Id = "1004", Stratum = 4},
                Date = DateTime.Now, Hour = DateTime.Now.Date
            };
            var serviceA = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            serviceA.Ejecute(requestA);

            var request = new PostponeMedicalAppointmentRequest
                {Identification = 1, Date = DateTime.Now.AddDays(3), Hour = DateTime.Now.Date.AddHours(14)};
            var service = new PostponeMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica aplazada satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void CancelMedicalAppointmentTest()
        {
            var requestA = new RegisterMedicalAppointmentRequest
            {
                Doctor = new Doctor {Id = "4444"}, Patient = new Patient {Id = "1004", Stratum = 4},
                Date = DateTime.Now, Hour = DateTime.Now.Date
            };
            var serviceA = new RegisterMedicalAppointmentService(new UnitOfWork(_context));
            serviceA.Ejecute(requestA);

            var request = new CancelMedicalAppointmentRequest {Identification = 1};
            var service = new CancelMedicalAppointmentService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Cita medica cancelada satisfactoriamente", response.Mensaje);
        }
    }
}