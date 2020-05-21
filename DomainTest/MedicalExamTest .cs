using NUnit.Framework;
using Domain.Entities;
using System;

namespace DomainTest
{
    public class MedicalExamTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegisterMedicalAppointmentCorrect()
        {
            Patient patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            MedicalExam medicalExam = new MedicalExam();
            medicalExam.Name = "Examen de orina";
            medicalExam.Date = DateTime.Now.AddDays(10);
            medicalExam.Date = medicalExam.Date.AddHours(8);
            medicalExam.Patient = patient;
            medicalExam.GenerateCost();

            Assert.AreEqual(20000, medicalExam.Cost);
        }

        
    }
}