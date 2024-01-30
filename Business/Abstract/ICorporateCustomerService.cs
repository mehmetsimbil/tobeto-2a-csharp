using Business.Requests.ComporateCustomer;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICorporateCustomerService
    {
        public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request);
        public DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request);
        public GetCorporateCustomerListResponse GetList(GetCorporateCustomerListRequest request);
        public UpdateCorporateCustomerResponse Update(UpdateCorporateCustomerRequest request);
    }
}
