using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryFuelDal : InMemoryEntityRepositoryBase<Fuel, int>, IFuelDal
    {
        protected override int generatedId()
        {
            int nextId = _entities.Count == 0 ? 1 : _entities.Max(e=>e.Id) +1;
            return nextId;
            
        }
        public void Update(Fuel fuel)
        {
            var fuelToUpdate = _entities.FirstOrDefault(x=> x.Id == fuel.Id);
            fuelToUpdate.Name= fuel.Name;
        }

        public void Delete(Fuel fuel)
        {
            var fuelToDelete = _entities.FirstOrDefault(x => x.Id == fuel.Id);
            _entities.Remove(fuelToDelete);
        }
    }
}
