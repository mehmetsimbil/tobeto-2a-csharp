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
        public TransmissionController()
        {
            _transmissionService = ServiceRegistration.TransmissionService;
        }
        [HttpGet]
        public ICollection<Transmission> GetList()
        {
            IList<Transmission> transmissionList = _transmissionService.GetList();
            return transmissionList;
        }

        [HttpPost]
        public ActionResult AddTransmissionResponse(AddTransmissionRequest request)
        {
            AddTransmissionResponse response = _transmissionService.Add(request);
            return CreatedAtAction(nameof(GetList), response);
        }
    }
}
