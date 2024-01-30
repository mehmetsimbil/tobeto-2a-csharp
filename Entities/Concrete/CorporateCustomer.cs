using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CorporateCustomer : Entity<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; }

        public CorporateCustomer(string companyName, string taxNo, string email, string password)
        {
            CompanyName = companyName;
            TaxNo = taxNo;
            Email = email;
            Password = password;
        }
        public CorporateCustomer()
        {
            
        }

    }
}
