using Business.Abstract;
using Business.Requests.Model;
using Business.Responses.Fuel;
using Business.Responses.Model;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpGet("GetModelList")]
        public GetModelListResponse GetModelList([FromQuery] GetModelListRequest request) 
        {
            GetModelListResponse response = _modelService.GetModelList(request);
            return response;
        }
        [HttpGet("GetByFuelId")]
        public ActionResult<List<Model>> GetFuelList(int id)
        {
            IList<Model> getFuelList = _modelService.GetFuelList(id);
            return getFuelList.ToList();
        }
        [HttpGet("GetByTransmissionId")]
        public ActionResult<List<Model>> GetTransmissionList(int id)
        {
            IList<Model> getTransmissionList = _modelService.GetTransmissionList(id);
            return getTransmissionList.ToList();
        }
        [HttpGet("GetByBrandId")]
        public ActionResult<List<Model>> GetBrandList(int id)
        {
            IList<Model> getBrandList = _modelService.GetBrandList(id);
            return getBrandList.ToList();
        }

        [HttpPost]
        public ActionResult<AddModelResponse> Add(AddModelRequest request)
        {
            AddModelResponse response = _modelService.AddModel(request);
            return response;
        }
    }
}
