﻿namespace Domain.Entities
{
    public class Doctor : Person
    {
        public int Experience { get; set; }
        public string Degree { get; set; }
        public string Workday { get; set; }

        /*public void GenerateWorkDay() 
        {
            switch (Degree)
            {
                case "Medico":
                    Workday = "Jornada Completa";
                    break;
                case "Pediatra":
                    Workday = "Mañana";
                    break;
                case "Odontologo":
                    Workday = "Mañana";
                    break;
                case "Oftalmologo":
                    Workday = "Tarde";
                    break;
            }
        }*/
    }
}