using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.ComporateCustomer
{
    public class AddCorporateCustomerRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }
    }
}
