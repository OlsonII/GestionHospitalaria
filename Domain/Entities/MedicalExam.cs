using System;
using Domain.Base;

namespace Domain.Entities
{
    public class MedicalExam : Entity<int>, IMedicalService
    {
        private const double Basecost = 50000;
        public override int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public Patient Patient { get; set; }
        public string State { get; set; }
        public double Cost { get; private set; }


        public void GenerateCost()
        {
            Cost = Basecost * (1 - Patient.Discount);
            State = "Asignada";
        }

        public void CompleteExam()
        {
            State = "Completado";
        }

        public void CancelExam()
        {
            State = "Cancelado";
        }

        public void PostponeExam(DateTime date, DateTime hour)
        {
            State = "Aplazado";
            Date = date;
            Hour = hour;
        }
    }
}