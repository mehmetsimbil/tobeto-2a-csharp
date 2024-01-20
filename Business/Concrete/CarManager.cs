using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Car;
using Business.Responses.Car;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private ICarDal _carDal;
    private readonly CarBusinessRules _carBusinessRules;
    private readonly IMapper _mapper;

    public CarManager(ICarDal carDal, CarBusinessRules carBusinessRules, IMapper mapper)
    {
        _carDal = carDal;
        _carBusinessRules = carBusinessRules;
        _mapper = mapper;
    }

    public AddCarResponse Add(AddCarRequest request)
    {
        _carBusinessRules.CheckCarModelYear(request.ModelYear);
        Car carToAdd = _mapper.Map<Car>(request);
        _carDal.Add(carToAdd);
        AddCarResponse response = _mapper.Map<AddCarResponse>(carToAdd);
        return response;
    }

    public GetCarListResponse GetList(GetCarListRequest request)
    {
        IList<Car> carList = _carDal.GetList();
        GetCarListResponse response = _mapper.Map<GetCarListResponse>(carList);
        return response;
    }
}
