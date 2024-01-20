using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Model
{
    public class AddModelRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public double DailyPrice { get; set; }
        public AddModelRequest(string name, int brandId, int transmissionId, int fuelId, int id, double dailyPrice)
        {
            Name = name;
            BrandId = brandId;
            TransmissionId = transmissionId;
            FuelId = fuelId;
            Id = id;
            DailyPrice = dailyPrice;
        }
    }
}
