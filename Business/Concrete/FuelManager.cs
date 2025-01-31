﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brand;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class FuelManager : IFuelService
    {
        private IFuelDal _fuelDal;
        private readonly FuelBusinessRules _fuelBusinessRules;
        private readonly IMapper _mapper;
        public FuelManager(IFuelDal fuelDal, FuelBusinessRules fuelBusinessRules, IMapper mapper)
        {
            _fuelDal = fuelDal;
            _fuelBusinessRules = fuelBusinessRules;
            _mapper = mapper;
        }


        public GetFuelListResponse GetList(GetFuelListRequest request)
        {
            IList<Fuel> fuelList = _fuelDal.GetList();
            GetFuelListResponse response = _mapper.Map<GetFuelListResponse>(fuelList);
            return response;
        }
       

        public AddFuelResponse Add(AddFuelRequest request)
        {
            _fuelBusinessRules.CheckIfFuelNameAlreadyExists(request.Name);
            Fuel fuelToAdd = _mapper.Map<Fuel>(request);
            _fuelDal.Add(fuelToAdd);
            AddFuelResponse response = _mapper.Map<AddFuelResponse>(fuelToAdd);
            return response;
        }

        public void Update(UpdateFuelRequest request)
        {
            Fuel fuel = _fuelDal.GetList().FirstOrDefault(x=> x.Id == request.Id);
            _fuelBusinessRules.CheckIfFuelExists(fuel.Id);
            Fuel fuelToUpdate = _mapper.Map<Fuel>(request);
            _fuelDal.Update(fuelToUpdate);
        }

        public void Delete(DeleteFuelRequest request)
        {
            Fuel fuel = _fuelDal.GetList().FirstOrDefault(x=> x.Id == request.Id);
            _fuelBusinessRules.CheckIfFuelExists(fuel.Id);
            Fuel fuelToDelete= _mapper.Map<Fuel>(request);
            _fuelDal.Delete(fuelToDelete);
        }

      
    }
}
