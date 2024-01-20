

namespace Business.Requests.Car
{
    public class AddCarRequest
    {
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public int ModelId { get; set; }
        public int CarState { get; set; }
        public int Kilometer { get; set; }
        public string Plate { get; set; }
        public int ColorId { get; set; }

        public AddCarRequest(string name,int modelYear, int modelId, int carState, int kilometer, string plate, int colorId) { 
            Name = name;
            ModelYear = modelYear;
            ModelId = modelId;
            CarState = carState;
            Kilometer = kilometer;
            Plate = plate;
            ColorId = colorId;
        }

    }

}
