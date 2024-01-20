

using DataAccess.Abstract;

namespace Business.BusinessRules
{
    public class CarBusinessRules
    {
        private readonly ICarDal _carDal;
        public CarBusinessRules(ICarDal carDal)
        {
            _carDal = carDal;   
        }
        public void CheckCarModelYear(int modelYear)
        {
            if(modelYear <= DateTime.Today.Year - 20)
            {
                throw new Exception("Model Year cannot be more than 20 years");
            }
        }
    }
}
