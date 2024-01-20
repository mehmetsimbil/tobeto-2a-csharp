using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryModelDal : InMemoryEntityRepositoryBase<Model, int>, IModelDal
{
    public void AddModel(Model model)
    {
        throw new NotImplementedException();
    }

    public IList<Model> GelModelList()
    {
        throw new NotImplementedException();
    }

    public IList<Model> GetBrandList(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Model> GetFuelList(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Model> GetTransmissionList(int id)
    {
        throw new NotImplementedException();
    }

    protected override int generatedId()
    {
        int nextId = _entities.Count == 0 ? 1 : _entities.Max(e => e.Id) + 1;
        return nextId;
    }
}
