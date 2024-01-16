using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Transmission
{
    public class UpdateTransmissionRequest
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public UpdateTransmissionRequest(string name,int id)
        {
            Name = name;
            Id = id;
        }
    }
}
