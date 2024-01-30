using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class IndividualCustomerBusinessRules
    {
        private readonly IIndividualCustomerDal _individualCustomerDal;

        public IndividualCustomerBusinessRules(IIndividualCustomerDal individualCustomerDal)
        {
            _individualCustomerDal = individualCustomerDal;
        }

        public void CheckIfIndividualCustomerNameExists(string firstName,string lastName)
        {
            bool isNameExists = _individualCustomerDal.Get(i=> i.FirstName == firstName && i.LastName == lastName) != null;
            if (isNameExists)
                throw new BusinessException("Individual Customer  already exists.");
        }

        public void CheckIfIndividualCustomerExists(IndividualCustomer customer)
        {
            if (customer is null)
                throw new NotFoundException("Individual Customer not found.");
        }
    }
}
