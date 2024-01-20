using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Model;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;
        private readonly ModelBusinessRules _modelBusinessRules;
        private readonly IMapper _mapper;

        public ModelManager(IModelDal modelDal,ModelBusinessRules modelBusinessRules,IMapper mapper)
        {
            _modelDal = modelDal;
            _modelBusinessRules = modelBusinessRules;
            _mapper = mapper;
        }

        public AddModelResponse AddModel(AddModelRequest request)
        {
            _modelBusinessRules.CheckModelNameCharacterNotEnough(request.Name);
            _modelBusinessRules.CheckModelDailyPrice(request.DailyPrice);
            Model modelToAdd = _mapper.Map<Model>(request);
            _modelDal.AddModel(modelToAdd);
            AddModelResponse response = _mapper.Map<AddModelResponse>(modelToAdd);
            return response;
        }

        public GetModelListResponse GetModelList(GetModelListRequest request)
        {
            IList<Model> modelList = _modelDal.GelModelList();
            GetModelListResponse response = _mapper.Map<GetModelListResponse>(modelList);
            return response;
        }

        public IList<Model> GetFuelList(int id)
        {
            var result = _modelDal.GetFuelList(id);
            return result;
        }

        public IList<Model> GetTransmissionList(int id)
        {
            var result = _modelDal.GetTransmissionList(id);
            return result;
        }

        public IList<Model> GetBrandList(int id)
        {
            var result = _modelDal.GetBrandList(id);
            return result;
        }
    }
    }

