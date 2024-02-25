﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserRole : Entity<int>
    {
        public Userr? User {  get; set; }
        public  int?  UserId { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
