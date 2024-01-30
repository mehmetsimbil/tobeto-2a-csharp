using Business.Requests.IndividualCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Validation.FluentValidation.IndividualCustomer
{
    public class AddIndividualCustomerRequestValidator : AbstractValidator<AddIndividualCustomerRequest>
    {
        public AddIndividualCustomerRequestValidator()
        {
            RuleFor(x=>x.Email).NotEmpty();
            RuleFor(x=>x.FirstName).NotEmpty();
            RuleFor(x=> x.LastName).NotEmpty();
            RuleFor(x=> x.NationalIdentity).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
        }
    }
}
