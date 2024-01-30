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
    public class CustomerBusinessRules
    {
        private readonly ICustomersDal _customersDal;

        public CustomerBusinessRules(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }

        public void CheckIfCustomerNameExists(string firstName, string lastName)
        {
            bool isNameExists = _customersDal.Get(c => c.FirstName == firstName && c.LastName == lastName) != null;
            if (isNameExists)
                throw new BusinessException("Customer  already exists.");
        }

        public void CheckIfCustomerExists(Customers? customer)
        {
            if (customer is null)
                throw new NotFoundException("Customer not found.");
        }
    }
}
