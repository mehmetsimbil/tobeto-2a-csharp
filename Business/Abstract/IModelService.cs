
using Business.Requests.Model;
using Business.Responses.Model;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IModelService 
    {
        public AddModelResponse AddModel(AddModelRequest request);
        public IList<Model> GetBrandList(int id);
        public IList<Model> GetFuelList(int id);
        public IList<Model> GetTransmissionList(int id);

        public GetModelListResponse GetModelList(GetModelListRequest request);
    }
}
