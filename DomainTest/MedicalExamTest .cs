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
        public void RegisterMedicalExamCorrect()
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

        [Test]
        public void CompleteMedicalExamCorrect()
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
            medicalExam.CompleteExam();

            Assert.AreEqual("Completado", medicalExam.State);
        }

        [Test]
        public void CancelMedicalExamCorrect()
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
            medicalExam.CancelExam();

            Assert.AreEqual("Cancelado", medicalExam.State);
        }

        [Test]
        public void PostponeMedicalExamCorrect()
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
            medicalExam.PostponeExam(medicalExam.Date.AddDays(5),medicalExam.Date);

            Assert.AreEqual("Aplazado", medicalExam.State);
        }
    }
}