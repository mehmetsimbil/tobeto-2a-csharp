using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FuelManager : IFuelService
    {
        private IFuelService _fuelService;
        public FuelManager(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }

        public Fuel Add(Fuel fuel)
        {
            _fuelService.Add(fuel);
            return fuel;
        }
    }
}
