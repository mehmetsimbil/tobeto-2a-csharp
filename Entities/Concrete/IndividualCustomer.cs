using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class IndividualCustomer : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NationalIdentity { get; set; }
        public IndividualCustomer(string nationalIdentity, string firstName, string lastName, string password, string email)
        {
            NationalIdentity = nationalIdentity;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
        }
        public IndividualCustomer()
        {
            
        }

    }
}
