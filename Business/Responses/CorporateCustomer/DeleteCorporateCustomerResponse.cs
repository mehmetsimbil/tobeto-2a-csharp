using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.CorporateCustomer
{
    public class DeleteCorporateCustomerResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
