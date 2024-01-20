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
    public class EfCarDal : InMemoryEntityRepositoryBase<Car, int>, ICarDal
    {
        protected override int generatedId()
        {

            int nextId = _entities.Count == 0
                ? 1
                : _entities.Max(e => e.Id) + 1;
            return nextId;
        }

    }
}
