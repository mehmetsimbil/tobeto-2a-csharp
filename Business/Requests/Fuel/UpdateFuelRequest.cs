using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Fuel
{
    public class UpdateFuelRequest
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public UpdateFuelRequest(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
