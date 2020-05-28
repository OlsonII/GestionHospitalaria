﻿using System;
using Domain.Base;

namespace Domain.Entities
{
    public class MedicalAppointment : Entity<int>, IMedicalService
    {
        private const double _BASECOST = 200000;


        public override int Id { get; set; }
        public Doctor Doctor { get; set; }

        public Prescription Prescription { get; set; }
        public Patient Patient { get; set; }
        public DateTime Hour { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public double Cost { get; private set; }

        public void GenerateCost()
        {
            Cost = _BASECOST * (1 - Patient.Discount);
            State = "Asignada";
        }

        public void CompleteMedicalAppointment(Prescription prescription)
        {
            Prescription = prescription;
            State = "Completada";
        }

        public void CancelMedicalAppointment()
        {
            State = "Cancelada";
        }

        public void PostponeMedicalAppointment(DateTime date, DateTime hour)
        {
            State = "Aplazada";
            Date = date;
            Hour = hour;
        }
    }
}