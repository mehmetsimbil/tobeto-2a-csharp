using Business.Dtos.CorporateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.CorporateCustomer
{
    public class GetCorporateCustomerListResponse
    {
        public ICollection<CorporateCustomerListItemDto> Items { get; set; }
    }
}
