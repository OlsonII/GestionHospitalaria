using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class RegisterDiscountByStratumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterDiscountByStratumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RegisterDiscountByStratumResponse Ejecute(RegisterDiscountByStratumRequest request)
        {
            var discount = new StratumConfiguration();
            discount.StratumOne = request.StratumOne;
            discount.StratumTwo = request.StratumTwo;
            discount.StratumThree = request.StratumThree;
            discount.StratumFour = request.StratumFour;
            discount.StratumFive = request.StratumFive;
            discount.StratumSix = request.StratumSix;
            _unitOfWork.StratumConfigurationRepository.Add(discount);
            _unitOfWork.Commit();
            return new RegisterDiscountByStratumResponse {Message = "Correcto"};
        }
    }

    public class RegisterDiscountByStratumRequest
    {
        public double StratumOne { get; set; }
        public double StratumTwo { get; set; }
        public double StratumThree { get; set; }
        public double StratumFour { get; set; }
        public double StratumFive { get; set; }
        public double StratumSix { get; set; }
    }

    public class RegisterDiscountByStratumResponse
    {
        public string Message { get; set; }
    }
}