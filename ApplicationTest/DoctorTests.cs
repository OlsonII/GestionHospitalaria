using Application;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ApplicationTest
{
    public class DoctorTests
    {
        private MedicalContext _context;
        
        [SetUp]
        public void Setup()
        {
            /*var optionsInDb = new DbContextOptionsBuilder<MedicalContext>()
                .UseSqlServer("Server=DESKTOP-N95GP02\\SQLEXPRESS;Database=MedicalServices;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            
            _context = new MedicalContext(optionsInDb);*/
            
            
            
            var optionsInMemory = new DbContextOptionsBuilder<MedicalContext>().UseInMemoryDatabase("MedicalServices").Options;

            _context = new MedicalContext(optionsInMemory);
            
            _context.Database.EnsureDeleted();
            
            var registerWorkdayRequest = new RegisterWorkdayByDegreeRequest(){DentistWorkday = "Mañana", DoctorWorkday = "Jornada Completa", OphthalmologistWorkday = "Tarde", PediatricianWorkday = "Mañana"};
            var registerWorkdayService = new RegisterWorkdayByDegreeService(new UnitOfWork(_context));
            registerWorkdayService.Ejecute(registerWorkdayRequest);
        }
        
        [Test]
        public void CreateDoctorTest()
        {
            var request = new RegisterDoctorRequest{ Identification = "1111", Name = "Doctor", Surname = "Prueba", Age = 30, Degree = "Medico", Experience = 7, Gender = "Masculino"};
            var service = new RegisterDoctorService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            
            Assert.AreEqual("Doctor registrado satisfactoriamente", response.Mensaje);
        }

        [Test]
        public void CreatePediatricianTest()
        {
            var request = new RegisterDoctorRequest{ Identification = "2222", Name = "Doctor", Surname = "Prueba", Age = 30, Degree = "Pediatra", Experience = 7, Gender = "Masculino"};
            var service = new RegisterDoctorService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Doctor registrado satisfactoriamente", response.Mensaje);
        }
        
        [Test]
        public void CreateDentistTest()
        {
            var request = new RegisterDoctorRequest{ Identification = "3333", Name = "Doctor", Surname = "Prueba", Age = 30, Degree = "Odontologo", Experience = 7, Gender = "Masculino"};
            var service = new RegisterDoctorService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Doctor registrado satisfactoriamente", response.Mensaje);
        }
        
        [Test]
        public void CreateOphthalmologistTest()
        {
            var request = new RegisterDoctorRequest{ Identification = "4444", Name = "Doctor", Surname = "Prueba", Age = 30, Degree = "Oftalmologo", Experience = 7, Gender = "Masculino"};
            var service = new RegisterDoctorService(new UnitOfWork(_context));
            var response = service.Ejecute(request);
            Assert.AreEqual("Doctor registrado satisfactoriamente", response.Mensaje);
        }
    }
}