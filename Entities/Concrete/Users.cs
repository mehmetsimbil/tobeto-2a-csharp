using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Users : Entity<int>
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Customers? Customer {  get; set; } = null;
        public int CustomerId { get; set; }
        public Users()
        {
        }

        public Users(string firstName,
            string lastName,
            string email,
            string password
,
            Customers? customer,
            int customerId
)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Customer = customer;
            CustomerId = customerId;

        }
    }
}
