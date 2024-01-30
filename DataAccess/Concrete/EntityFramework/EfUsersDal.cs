using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUsersDal : IUsersDal
    {
        private readonly RentACarContext _context;

        public EfUsersDal(RentACarContext context)
        {
            _context = context;
        }

        public Users Add(Users entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Users Delete(Users entity, bool isSoftDelete = true)
        {
            entity.DeletedAt = DateTime.UtcNow;
            if (!isSoftDelete)
                _context.Users.Remove(entity);

            _context.SaveChanges();
            return entity;
        }

        public Users? Get(Func<Users, bool> predicate)
        {
            Users? user = _context.Users.FirstOrDefault(predicate);
            return user;
        }

        public IList<Users> GetList(Func<Users, bool>? predicate = null)
        {
            IQueryable<Users> query = _context.Set<Users>();
            if(predicate != null)
                query = query.Where(predicate).AsQueryable();
            return query.ToList();
        }

        public Users Update(Users entity)
        {
            entity.UpdateAt = DateTime.UtcNow;
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
