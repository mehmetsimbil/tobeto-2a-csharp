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
    public class EfCorporateCustomerDal : ICorporateCustomerDal
    {
        private readonly RentACarContext _context;

        public EfCorporateCustomerDal(RentACarContext context)
        {
            _context = context;
        }

        public CorporateCustomer Add(CorporateCustomer entity)
        {
           entity.CreatedAt = DateTime.UtcNow;
            _context.CorporateCustomers.Add(entity);
            _context.SaveChanges();
            return entity;
           
        }

        public CorporateCustomer Delete(CorporateCustomer entity, bool isSoftDelete = true)
        {
            entity.DeletedAt = DateTime.UtcNow;
            if (!isSoftDelete)
                _context.CorporateCustomers.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public CorporateCustomer? Get(Func<CorporateCustomer, bool> predicate)
        {
            CorporateCustomer? corporateCustomer = _context.CorporateCustomers.FirstOrDefault(predicate);
            return corporateCustomer;
        }

        public IList<CorporateCustomer> GetList(Func<CorporateCustomer, bool>? predicate = null)
        {
            IQueryable<CorporateCustomer> query = _context.Set<CorporateCustomer>();
            if(predicate != null)
                query = query.Where(predicate).AsQueryable();
            return query.ToList();
        }

        public CorporateCustomer Update(CorporateCustomer entity)
        {
            entity.UpdateAt = DateTime.UtcNow;
            _context.CorporateCustomers.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
