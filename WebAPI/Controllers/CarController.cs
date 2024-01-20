using Business.Abstract;
using Business.Requests.Car;
using Business.Responses.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public GetCarListResponse GetList([FromQuery]GetCarListRequest request)
        {
            GetCarListResponse response = _carService.GetList(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddCarResponse> Add(AddCarRequest request)
        {
            AddCarResponse response = _carService.Add(request);
            return CreatedAtAction(nameof(GetList), response);
        }
    }
}
