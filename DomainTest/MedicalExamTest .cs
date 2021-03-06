using System;
using Domain.Entities;
using NUnit.Framework;

namespace DomainTest
{
    public class MedicalExamTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegisterMedicalExamCorrect()
        {
            var patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            var medicalExam = new MedicalExam();
            medicalExam.Name = "Examen de orina";
            medicalExam.Date = DateTime.Now.AddDays(10);
            medicalExam.Date = medicalExam.Date.AddHours(8);
            medicalExam.Patient = patient;
            medicalExam.GenerateCost();

            Assert.AreEqual(20000, medicalExam.Cost);
        }

        [Test]
        public void CompleteMedicalExamCorrect()
        {
            var patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            var medicalExam = new MedicalExam();
            medicalExam.Name = "Examen de orina";
            medicalExam.Date = DateTime.Now.AddDays(10);
            medicalExam.Date = medicalExam.Date.AddHours(8);
            medicalExam.Patient = patient;
            medicalExam.GenerateCost();
            medicalExam.CompleteExam();

            Assert.AreEqual("Completado", medicalExam.State);
        }

        [Test]
        public void CancelMedicalExamCorrect()
        {
            var patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            var medicalExam = new MedicalExam();
            medicalExam.Name = "Examen de orina";
            medicalExam.Date = DateTime.Now.AddDays(10);
            medicalExam.Date = medicalExam.Date.AddHours(8);
            medicalExam.Patient = patient;
            medicalExam.GenerateCost();
            medicalExam.CancelExam();

            Assert.AreEqual("Cancelado", medicalExam.State);
        }

        [Test]
        public void PostponeMedicalExamCorrect()
        {
            var patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            var medicalExam = new MedicalExam();
            medicalExam.Name = "Examen de orina";
            medicalExam.Date = DateTime.Now.AddDays(10);
            medicalExam.Date = medicalExam.Date.AddHours(8);
            medicalExam.Patient = patient;
            medicalExam.GenerateCost();
            medicalExam.PostponeExam(medicalExam.Date.AddDays(5), 2);

            Assert.AreEqual("Aplazado", medicalExam.State);
        }
    }
}