using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Brand
{
    public class AddBrandRequest
    {
        //DTO
        public string Name { get; set; }
        public AddBrandRequest(string name)
        {
            Name = name;
        }
    }
}
