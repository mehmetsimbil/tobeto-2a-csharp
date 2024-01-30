using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.BusinessRules
{
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerDal _corporateCustomerDal;

        public CorporateCustomerBusinessRules(ICorporateCustomerDal corporateCustomerDal)
        {
            _corporateCustomerDal = corporateCustomerDal;

        }
        public void CheckIfCorporateCustomerNameExists( string companyName)
        {
            bool isNameExists = _corporateCustomerDal.Get(c => c.CompanyName==companyName) != null;
            if (isNameExists)
                throw new BusinessException(" Corporate Customer  already exists.");
        }

        public void CheckIfCorporateCustomerExists(CorporateCustomer customer)
        {
            if (customer is null)
                throw new NotFoundException("Corporate Customer not found.");
        }
    }
}
