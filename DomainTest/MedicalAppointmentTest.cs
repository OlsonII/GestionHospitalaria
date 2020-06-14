using System;
using Domain.Entities;
using NUnit.Framework;

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
            var doctor = new Doctor();
            doctor.Id = "1065";
            doctor.Name = "Juan";
            doctor.Surname = "Robledo";
            doctor.Age = 35;
            doctor.Gender = "Masculino";
            doctor.Experience = 15;
            doctor.Degree = "Medico";
            doctor.Workday = "Jornada Completa";

            var patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            var medicalAppointment = new MedicalAppointment();
            medicalAppointment.Date = DateTime.Now.AddDays(10);
            medicalAppointment.Time = doctor.Workday;
            medicalAppointment.Doctor = doctor;
            medicalAppointment.Patient = patient;
            medicalAppointment.GenerateCost();

            Assert.AreEqual(80000, medicalAppointment.Cost);
        }

        [Test]
        public void CompleteMedicalAppointmentCorrect()
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

            var patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            var medicalAppointment = new MedicalAppointment();
            medicalAppointment.Date = DateTime.Now.AddDays(10);
            medicalAppointment.Time = doctor.Workday;
            medicalAppointment.Doctor = doctor;
            medicalAppointment.Patient = patient;
            medicalAppointment.GenerateCost();

            var prescription = new Prescription();

            medicalAppointment.CompleteMedicalAppointment(prescription);

            Assert.AreEqual("Completada", medicalAppointment.State);
        }

        [Test]
        public void CancelMedicalAppointmentCorrect()
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

            var patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            var medicalAppointment = new MedicalAppointment();
            medicalAppointment.Date = DateTime.Now.AddDays(10);
            medicalAppointment.Time = doctor.Workday;
            medicalAppointment.Doctor = doctor;
            medicalAppointment.Patient = patient;
            medicalAppointment.GenerateCost();

            var prescription = new Prescription();

            medicalAppointment.CancelMedicalAppointment();

            Assert.AreEqual("Cancelada", medicalAppointment.State);
        }

        [Test]
        public void PostponeMedicalAppointmentCorrect()
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

            var patient = new Patient();
            patient.Id = "1066";
            patient.Name = "Pedro";
            patient.Surname = "Salcedo";
            patient.Age = 25;
            patient.Gender = "Masculino";
            patient.EPS = "Saludvida";
            patient.Stratum = 2;
            patient.Discount = 0.6;

            var medicalAppointment = new MedicalAppointment();
            medicalAppointment.Date = DateTime.Now.AddDays(10);
            medicalAppointment.Time = doctor.Workday;
            medicalAppointment.Doctor = doctor;
            medicalAppointment.Patient = patient;
            medicalAppointment.GenerateCost();

            var prescription = new Prescription();

            medicalAppointment.PostponeMedicalAppointment(medicalAppointment.Date.AddDays(5), 2);

            Assert.AreEqual("Aplazada", medicalAppointment.State);
        }
    }
}