using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class BrandBusinessRules
    {
        private readonly IBrandDal _brandDal;
        public BrandBusinessRules(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void CheckIfBrandNameAlreadyExist(string brandName) {
        bool isExist = _brandDal.GetList().Any(b=>b.Name == brandName);
            if (isExist)
            {
                throw new BusinessException("Brand already exists.");
            }
        }
    }
}
