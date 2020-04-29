using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public interface IMedicalService
    {
        string Code { get; set; }
        Patient Patient { get; set; }
        DateTime Hour { get; set; }
        DateTime Date { get; set; }
        string State { get; set; }
        double Cost  { get; }

        void GenerateCost();
        
    }
}
