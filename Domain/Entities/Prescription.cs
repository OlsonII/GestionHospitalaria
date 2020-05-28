using System;
using System.Collections.Generic;
using Domain.Base;

namespace Domain.Entities
{
    public class Prescription : Entity<int>
    {
        public Prescription()
        {
            Medicines = new List<Medicine>();
        }

        public override int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<Medicine> Medicines { get; set; }
        public string State { get; set; }
    }
}