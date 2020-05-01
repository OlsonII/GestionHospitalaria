using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Prescription
    {
        public int Code { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<Medicine> Medicines { get; set; }
        public string State { get; set; }

        public Prescription()
        {
            Medicines = new List<Medicine>();
        }
    }
}
