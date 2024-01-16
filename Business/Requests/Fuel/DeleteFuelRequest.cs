using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Fuel
{
    public class DeleteFuelRequest
    {
        public int Id { get; set; }
        public DeleteFuelRequest(int id)
        {
            Id = id;
        }
    }
}
