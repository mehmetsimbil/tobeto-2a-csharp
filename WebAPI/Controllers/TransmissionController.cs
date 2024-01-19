using Business.Abstract;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : ControllerBase
    {
        private readonly ITransmissionService _transmissionService;
        public TransmissionController(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }
        [HttpGet("GetList")]
        public GetTransmissionListResponse GetList([FromQuery] GetTransmissionListRequest request)
        {
            GetTransmissionListResponse response = _transmissionService.GetList(request);
            return response;
        }

        [HttpPost("Add")]
        public ActionResult AddTransmissionResponse(AddTransmissionRequest request)
        {
            AddTransmissionResponse response = _transmissionService.Add(request);
            return CreatedAtAction(nameof(GetList), response);
        }

        [HttpPut("Update")]
        public void Update(UpdateTransmissionRequest request)
        {
            _transmissionService.Update(request);
        }

        [HttpDelete("Delete")]
        public void Delete(DeleteTransmissionRequest request)
        {
            _transmissionService.Delete(request);
        }
    }
}
