using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public Car Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Delete(Car entity, bool isSoftDelete = true)
        {
            throw new NotImplementedException();
        }

        public Car? Get(Func<Car, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<Car> GetList(Func<Car, bool>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public Car Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
