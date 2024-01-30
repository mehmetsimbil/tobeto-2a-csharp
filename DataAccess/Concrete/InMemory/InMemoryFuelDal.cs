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
            int nextId = Entities.Count == 0 ? 1 : Entities.Max(e=>e.Id) +1;
            return nextId;
            
        }
        public void Update(Fuel fuel)
        {
            var fuelToUpdate = Entities.FirstOrDefault(x=> x.Id == fuel.Id);
            fuelToUpdate.Name= fuel.Name;
        }

        public void Delete(Fuel fuel)
        {
            var fuelToDelete = Entities.FirstOrDefault(x => x.Id == fuel.Id);
            Entities.Remove(fuelToDelete);
        }
    }
}
