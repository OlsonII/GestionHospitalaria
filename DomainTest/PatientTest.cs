using NUnit.Framework;
using Domain.Entities;

namespace DomainTest
{
    public class PatientTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerateDiscountPatientCorrect()
        {
            Patient patient = new Patient();
            patient.Id = "1065";
            patient.Name = "Juan";
            patient.Surname = "Robledo";
            patient.Age = 35;
            patient.Stratum = 1;
            patient.EPS = "EPSEjemplo";
            patient.Discount = 0.7;
            Assert.AreEqual(0.7, patient.Discount);
        }
    }
}