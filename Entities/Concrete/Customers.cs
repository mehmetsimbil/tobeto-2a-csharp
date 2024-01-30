using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customers : Entity<int>

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IndividualCustomer? IndividualCustomer { get; set; } = null;
        public CorporateCustomer? CorporateCustomer { get; set; } = null;
        public int IndividualCustomerId { get; set; }
        public int CorporateCustomerId { get; set; }
    
        public Customers()
        {
            
        }

        public Customers(IndividualCustomer? individualCustomer, CorporateCustomer? corporateCustomer, int individualCustomerId, int corporateCustomerId, string firstName, string lastName, string email, string password)
        {
            IndividualCustomer = individualCustomer;
            CorporateCustomer = corporateCustomer;
            IndividualCustomerId = individualCustomerId;
            CorporateCustomerId = corporateCustomerId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
    }
    
