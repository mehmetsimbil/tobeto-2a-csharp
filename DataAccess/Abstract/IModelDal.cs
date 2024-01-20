using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;
public interface IModelDal : IEntityRepository<Model, int>
{
    public void AddModel(Model model);
    public IList<Model> GelModelList();
    public IList<Model> GetBrandList(int id);
    public IList<Model> GetFuelList(int id);
    public IList<Model> GetTransmissionList(int id);
}