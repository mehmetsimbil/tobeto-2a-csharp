using Core.Entities;

namespace Entities.Concrete;

public class Model : Entity<int>
{
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public short Year { get; set; }
    public Brand? Brand { get; set; } = null;
    public Fuel? Fuel { get; set; } = null;
    public Transmission? Transmission { get; set; } = null;
    public Model()
    {
        
    }

    public Model(
        int brandId,
        int fuelId, 
        int transmissionId, 
        string name, 
        double dailyPrice, 
        short year, 
        Brand? brand, 
        Fuel? fuel, 
        Transmission? transmission)
    {
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        Name = name;
        DailyPrice = dailyPrice;
        Year = year;
        Brand = brand;
        Fuel = fuel;
        Transmission = transmission;
    }
}
