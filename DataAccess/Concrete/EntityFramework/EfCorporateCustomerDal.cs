using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCorporateCustomerDal : EfEntityRepositoryBase<CorporateCustomer, int, RentACarContext>, ICorporateCustomerDal
    {
        public EfCorporateCustomerDal(RentACarContext context) : base(context)
        {
        }
    }

}
