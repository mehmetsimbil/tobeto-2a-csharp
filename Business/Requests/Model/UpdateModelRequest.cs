using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Model
{
    public class UpdateModelRequest
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }
        public string Name { get; set; }
        public short Year { get; set; }
        public double DailyPrice { get; set; }
    }
}
