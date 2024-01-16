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
    public class InMemoryTransmissionDal : InMemoryEntityRepositoryBase<Transmission, int>, ITransmissionDal
    {
        protected override int generatedId()
        {
            int nextId = _entities.Count == 0 ? 1 : _entities.Max(e => e.Id) + 1;
            return nextId;
        }

        public void Update(Transmission transmission)
        {
            var transmissionToUpdate = _entities.FirstOrDefault(x => x.Id == transmission.Id);
            transmissionToUpdate.Name = transmission.Name;
        }

        public void Delete(Transmission transmission)
        {
            var transmissionToDelete = _entities.FirstOrDefault(x => x.Id == transmission.Id);
            _entities.Remove(transmissionToDelete);
        }
    }
}
