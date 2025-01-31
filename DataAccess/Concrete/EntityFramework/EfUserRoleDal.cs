﻿using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserRoleDal : EfEntityRepositoryBase<UserRole, int, RentACarContext>, IUserRoleDal
    {
        public EfUserRoleDal(RentACarContext context) : base(context)
        {
        }
    }
}
