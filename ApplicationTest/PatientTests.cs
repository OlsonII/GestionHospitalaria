using Application;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ApplicationTest
{
    public class PatientTests
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
        public void CreatePatientStratum1Test()
        {
            var request = new RegisterPatientRequest{ Identification = "1001", Name = "Paciente1", Surname = "Prueba", Age = 25, Gender = "Masculino", Stratum = 1, EPS = "EpsExample"};
            var service = new RegisterPatientService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Paciente registrado satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void CreatePatientStratum2Test()
        {
            var request = new RegisterPatientRequest { Identification = "1002", Name = "Paciente2", Surname = "Prueba", Age = 25, Gender = "Masculino", Stratum = 2, EPS = "EpsExample" };
            var service = new RegisterPatientService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Paciente registrado satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void CreatePatientStratum3Test()
        {
            var request = new RegisterPatientRequest { Identification = "1003", Name = "Paciente3", Surname = "Prueba", Age = 25, Gender = "Masculino", Stratum = 3, EPS = "EpsExample" };
            var service = new RegisterPatientService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Paciente registrado satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void CreatePatientStratum4Test()
        {
            var request = new RegisterPatientRequest { Identification = "1004", Name = "Paciente4", Surname = "Prueba", Age = 25, Gender = "Masculino", Stratum = 4, EPS = "EpsExample" };
            var service = new RegisterPatientService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Paciente registrado satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void CreatePatientStratum5Test()
        {
            var request = new RegisterPatientRequest { Identification = "1005", Name = "Paciente5", Surname = "Prueba", Age = 25, Gender = "Masculino", Stratum = 5, EPS = "EpsExample" };
            var service = new RegisterPatientService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Paciente registrado satisfactoriamente", response.Mensaje);
        }
    }
}