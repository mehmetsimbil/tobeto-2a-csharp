using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Model
{
    public class GetModelListRequest
    {
        public int? FilterByBrandId { get; set; }
        public int? FilterByFuelId { get; set; }
        public int? FilterByTransmissionId { get; set; }
    }
}
