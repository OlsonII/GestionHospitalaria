using Domain.Contracts;
using Domain.Entities;

namespace Application
{
    public class SearchDiscountByStratumService
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public SearchDiscountByStratumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public SearchDiscountByStratumResponse Ejecute(SearchDiscountByStratumRequest request)
        {
            var discount = _unitOfWork.StratumConfigurationRepository.FindFirstOrDefault(s => s.Id == 1);

            return new SearchDiscountByStratumResponse(){Discount = SelectDiscountByStratum(request, discount)};
        }

        private double SelectDiscountByStratum(SearchDiscountByStratumRequest request, StratumConfiguration discount)
        {
            var newDiscount = 0.0;
            switch (request.Stratum)
            {
                case 1:
                    newDiscount = discount.StratumOne;
                    break;
                case 2:
                    newDiscount = discount.StratumTwo;
                    break;
                case 3:
                    newDiscount = discount.StratumThree;
                    break;
                case 4:
                    newDiscount = discount.StratumFour;
                    break;
                case 5:
                    newDiscount = discount.StratumFive;
                    break;
                case 6:
                    newDiscount = discount.StratumSix;
                    break;
            }

            return newDiscount;
        }
    }

    public class SearchDiscountByStratumRequest
    {
        public int Stratum { get; set; }
    }

    public class SearchDiscountByStratumResponse
    {
        public double Discount { get; set; }
    }
}