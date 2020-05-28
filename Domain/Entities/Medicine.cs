using Domain.Base;

namespace Domain.Entities
{
    public class Medicine : Entity<int>
    {
        public Medicine()
        {
        }

        public Medicine(string name, int quantity, double periodicity)
        {
            Name = name;
            Quantity = quantity;
            Periodicity = periodicity;
        }

        public override int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Periodicity { get; set; }
    }
}