using Core.DataAccess.InMemory;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : InMemoryEntityRepositoryBase<Model, int>, IModelDal
    {
        private readonly HashSet<Model> _entities = new();

        protected override int generatedId()
        {
            int nextId = _entities.Count == 0
                ? 1
                : _entities.Max(e => e.Id) + 1;
            return nextId;
        }
        public IList<Model> GetBrandList(int id)
        {
            IList<Model> entities = _entities.Where(e => e.DeletedAt.HasValue == false && e.BrandId==id).ToList();
            return entities;
        }

        public IList<Model> GetFuelList(int id)
        {
            IList<Model> entities = _entities.Where(e => e.DeletedAt.HasValue == false && e.FuelId == id ).ToList();
            return entities;
        }

        public IList<Model> GetTransmissionList(int id)
        {
            IList<Model> entities = _entities.Where(e => e.DeletedAt.HasValue == false && e.TransmissionId == id).ToList();
            return entities;
        }

        public void AddModel(Model model)
        {
            model.CreatedAt = DateTime.UtcNow;
               _entities.Add(model);
        }

        public IList<Model> GelModelList()
        {
            IList<Model> entities = _entities.Where(e => e.DeletedAt.HasValue == false).ToList();
            return entities;
        }
    }
}
