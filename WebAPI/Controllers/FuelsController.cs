using Business.Abstract;
using Business.Requests.Fuel;
using Business.Responses.Brand;
using Business.Responses.Fuel;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        private readonly IFuelService _fuelService;
        public FuelsController(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }
        [HttpGet("GetList")]
        public GetFuelListResponse GetList([FromQuery] GetFuelListRequest request)
        {
            GetFuelListResponse response = _fuelService.GetList(request);
            return response;
        }

        [HttpPost("Add")]
        public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
        {
            AddFuelResponse response = _fuelService.Add(request);
            return CreatedAtAction(nameof(GetList), response);
        }
        [HttpPut("Update")]
        public void Update(UpdateFuelRequest request)
        {
            _fuelService.Update(request);
        }
        [HttpDelete("Delete")]
        public void Delete(DeleteFuelRequest request)
        {
            _fuelService.Delete(request);
        }
    }
}
