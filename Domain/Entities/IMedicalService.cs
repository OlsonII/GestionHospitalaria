using System;

namespace Domain.Entities
{
    public interface IMedicalService
    {
        Patient Patient { get; set; }
        DateTime Hour { get; set; }
        DateTime Date { get; set; }
        string State { get; set; }
        double Cost { get; }

        void GenerateCost();
    }
}