using NUnit.Framework;
using Domain.Entities;

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
            Doctor doctor = new Doctor();
            doctor.Identification = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Pediatra";
            doctor.GenerateWorkDay();
            Assert.AreEqual("Mañana", doctor.Workday);
        }

        [Test]
        public void GenerateWorkdayDoctorCorrect()
        {
            Doctor doctor = new Doctor();
            doctor.Identification = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Medico";
            doctor.GenerateWorkDay();
            Assert.AreEqual("Jornada Completa", doctor.Workday);
        }

        [Test]
        public void GenerateWorkdayOphthalmologistCorrect()
        {
            Doctor doctor = new Doctor();
            doctor.Identification = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Oftalmologo";
            doctor.GenerateWorkDay();
            Assert.AreEqual("Tarde", doctor.Workday);
        }

        [Test]
        public void GenerateWorkdayDentistCorrect()
        {
            Doctor doctor = new Doctor();
            doctor.Identification = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Odontologo";
            doctor.GenerateWorkDay();
            Assert.AreEqual("Mañana", doctor.Workday);
        }
    }
}