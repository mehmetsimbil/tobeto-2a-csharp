using Business.Requests.ComporateCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Validation.FluentValidation.CorporateCustomer
{
    public class AddCorporateCustomerRequestValidator : AbstractValidator<AddCorporateCustomerRequest>
    {
        public AddCorporateCustomerRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x=> x.CompanyName).NotEmpty();
            RuleFor(x=>x.TaxNo).NotEmpty();
        }
    }
}
