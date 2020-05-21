using NUnit.Framework;
using Domain.Entities;
using System;

namespace DomainTest
{
    public class MedicalAppointmentTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegisterMedicalAppointmentCorrect()
        {
            Doctor doctor = new Doctor();
            doctor.Id = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Medico";
            doctor.Workday = "Jornada Completa";

            Patient patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            MedicalAppointment medicalAppointment = new MedicalAppointment();
            medicalAppointment.Date = DateTime.Now.AddDays(10);
            medicalAppointment.Hour = medicalAppointment.Date.AddHours(8);
            medicalAppointment.Doctor = doctor;
            medicalAppointment.Patient = patient;
            medicalAppointment.GenerateCost();

            Assert.AreEqual(80000, medicalAppointment.Cost);
        }
    }
}