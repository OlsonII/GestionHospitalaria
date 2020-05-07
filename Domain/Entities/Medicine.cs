using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entities
{
    public class Medicine : Entity<int>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Periodicity { get; set; }

        public Medicine()
        {
        }

        public Medicine(string name, int quantity, double periodicity)
        {
            Name = name;
            Quantity = quantity;
            Periodicity = periodicity;
        }
    }
}
