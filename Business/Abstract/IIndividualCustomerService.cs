using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIndividualCustomerService
    {
        public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request);
        public DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest request);
        public UpdateIndividualCustomerResponse Update(UpdateIndividualCustomerRequest request);
        public GetIndividualCustomerListResponse GetList(GetIndividualCustomerListRequest request);
    }
}
