using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Patient : Person
    {

        public string EPS { get; set; }
        public int Stratum { get; set; }
        public double Discount { get; private set; }

        public Patient(){}

        public void GenerateDiscount() 
        {
            switch (this.Stratum)
            {
                case 1:
                    this.Discount = 0.7;
                    break;
                case 2:
                    this.Discount = 0.6;
                    break;
                case 3:
                    this.Discount = 0.5;
                    break;
                case 4:
                    this.Discount = 0.0;
                    break;
                case 5:
                    this.Discount = 0.0;
                    break;
                case 6:
                    this.Discount = 0.0;
                    break;
            }            
        }

    }
}
