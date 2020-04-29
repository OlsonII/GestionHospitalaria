using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Doctor : Person
    {
        public int Experience { get; set; }
        public string Degree { get; set; }
        public string Workday { get; private set; }

        public Doctor(){}



    }
}
