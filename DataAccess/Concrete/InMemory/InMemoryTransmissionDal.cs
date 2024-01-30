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
            int nextId = Entities.Count == 0 ? 1 : Entities.Max(e => e.Id) + 1;
            return nextId;
        }

        public void Update(Transmission transmission)
        {
            var transmissionToUpdate = Entities.FirstOrDefault(x => x.Id == transmission.Id);
            transmissionToUpdate.Name = transmission.Name;
        }

        public void Delete(Transmission transmission)
        {
            var transmissionToDelete = Entities.FirstOrDefault(x => x.Id == transmission.Id);
            Entities.Remove(transmissionToDelete);
        }
    }
}
