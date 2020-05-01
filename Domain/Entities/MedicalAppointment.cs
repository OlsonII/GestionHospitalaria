using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class MedicalAppointment : IMedicalService
    {
        public string Code { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime Hour { get; set; }
        public DateTime Date { get; set; }
        public Prescription Prescription { get; set; }
        public string State { get; set; }
        public double Cost { get; private set; }

        private const double _BASECOST = 200000;


        public MedicalAppointment() { }

        public void GenerateCost() 
        {
            Cost = _BASECOST * (1 - Patient.Discount);
            this.State = "Asignada";
        }
    }
}
