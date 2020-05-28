using Domain.Entities;
using NUnit.Framework;

namespace DomainTest
{
    public class DoctorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerateWorkdayPediatricianCorrect()
        {
            var doctor = new Doctor();
            doctor.Id = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Pediatra";
            doctor.Workday = "Mañana";
            Assert.AreEqual("Mañana", doctor.Workday);
        }

        [Test]
        public void GenerateWorkdayDoctorCorrect()
        {
            var doctor = new Doctor();
            doctor.Id = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Medico";
            doctor.Workday = "Jornada Completa";
            Assert.AreEqual("Jornada Completa", doctor.Workday);
        }

        [Test]
        public void GenerateWorkdayOphthalmologistCorrect()
        {
            var doctor = new Doctor();
            doctor.Id = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Oftalmologo";
            doctor.Workday = "Tarde";
            Assert.AreEqual("Tarde", doctor.Workday);
        }

        [Test]
        public void GenerateWorkdayDentistCorrect()
        {
            var doctor = new Doctor();
            doctor.Id = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Odontologo";
            doctor.Workday = "Mañana";
            Assert.AreEqual("Mañana", doctor.Workday);
        }
    }
}