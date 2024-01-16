using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class TransmissionBusinessRules
    {
        private ITransmissionDal _transmissionDal;
        public TransmissionBusinessRules(ITransmissionDal transmissionDal)
        {
            _transmissionDal = transmissionDal;
        }

        public void CheckIfTransmissionNameAlreadyExists(string transmissionName)
        {
            bool isExists = _transmissionDal.GetList().Any(x=>x.Name == transmissionName);
            if (isExists) {
                throw new Exception("Transmission already exists.");
            }
        }
    }
}
