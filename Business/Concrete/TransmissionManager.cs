using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TransmissionManager : ITransmissionService
    {
        private ITransmissionService _transmissionService;
        public TransmissionManager(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }

        public Transmission Add(Transmission transmission)
        {
            _transmissionService.Add(transmission);
            return transmission;
        }
    }
}
