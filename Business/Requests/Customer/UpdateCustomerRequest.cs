using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Customer
{
    public class UpdateCustomerRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IndividualCustomerId { get; set; }
        public int CorporateCustomerId { get; set; }
    }
}
