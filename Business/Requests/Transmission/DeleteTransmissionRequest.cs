using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Transmission
{
    public class DeleteTransmissionRequest
    {
        public int Id { get; set; }

        public DeleteTransmissionRequest(int id)
        {
            Id = id;
        }
    }
}
