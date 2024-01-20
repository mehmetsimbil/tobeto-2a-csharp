using Business.Dtos.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Car
{
    public class GetCarListResponse
    {
        public ICollection<CarListItemDto> Items {  get; set; }
        public GetCarListResponse()
        {
            Items=Array.Empty<CarListItemDto>();
        }

        public GetCarListResponse(ICollection<CarListItemDto> items)
        {
            Items = items;
        }
    }
}
