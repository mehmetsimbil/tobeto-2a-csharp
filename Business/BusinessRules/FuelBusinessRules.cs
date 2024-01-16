using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class FuelBusinessRules
    {
        private IFuelDal _fuelDal;
        public FuelBusinessRules(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }
        public void CheckIfFuelNameAlreadyExists(string fuelName) {
        bool isExists = _fuelDal.GetList().Any(x =>  x.Name == fuelName);
            if(isExists)
            {
                throw new Exception("Fuel already exists.");
            }
        }

    }
}
