using Business.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Customer
{
    public class GetCustomerListResponse
    {
        public ICollection<CustomerListItemDto> Items { get; set; }
    }
}
