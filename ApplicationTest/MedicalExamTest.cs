using System;
using Application;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ApplicationTest
{
    public class MedicalExamTest
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
        public void RegisterMedicalExamTest()
        {
            var request = new RegisterMedicalExamRequest
                {Patient = new Patient {Id = "1004", Stratum = 2}, Date = DateTime.Now};
            var service = new RegisterMedicalExamService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Examen medico creado satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void CompleteMedicalAppointmentTest()
        {
            var requestA = new RegisterMedicalExamRequest
                {Patient = new Patient {Id = "1004", Stratum = 2}, Date = DateTime.Now};
            var serviceA = new RegisterMedicalExamService(new UnitOfWork(_context));
            serviceA.Ejecute(requestA);

            var request = new CompleteMedicalExamRequest {Identification = 1};
            var service = new CompleteMedicalExamService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Examen completado Correctamente", response.Mensaje);
        }

        [Test]
        public void PostponeMedicalAppointmentTest()
        {
            var requestA = new RegisterMedicalExamRequest
                {Patient = new Patient {Id = "1004", Stratum = 2}, Date = DateTime.Now};
            var serviceA = new RegisterMedicalExamService(new UnitOfWork(_context));
            serviceA.Ejecute(requestA);

            var request = new PostponeMedicalExamRequest
                {Identification = 1, Date = DateTime.Now.AddDays(3)};
            var service = new PostponeMedicalExamService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Examen aplazado Correctamente", response.Mensaje);
        }

        [Test]
        public void CancelMedicalAppointmentTest()
        {
            var requestA = new RegisterMedicalExamRequest
                {Patient = new Patient {Id = "1004", Stratum = 2}, Date = DateTime.Now};
            var serviceA = new RegisterMedicalExamService(new UnitOfWork(_context));
            serviceA.Ejecute(requestA);

            var request = new CancelMedicalExamRequest {Identification = 1};
            var service = new CancelMedicalExamService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Examen cancelado Correctamente", response.Mensaje);
        }
    }
}