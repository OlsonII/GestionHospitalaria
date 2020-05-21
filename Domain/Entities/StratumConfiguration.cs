using Domain.Base;

namespace Domain.Entities
{
    public class StratumConfiguration : Entity<int>
    {
        public double StratumOne { get; set; }
        public double StratumTwo { get; set; }
        public double StratumThree { get; set; }
        public double StratumFour { get; set; }
        public double StratumFive { get; set; }
        public double StratumSix { get; set; }
        
        public StratumConfiguration()
        {
        }
    }
}