using Domain.Base;

namespace Domain.Entities
{
    public class WorkdayConfiguration : Entity<int>
    {
        public string DoctorWorkday { get; set; }
        public string PediatricianWorkday { get; set; }
        public string OphthalmologistWorkday { get; set; }
        public string DentistWorkday { get; set; }

        public WorkdayConfiguration()
        {
        }
    }
}