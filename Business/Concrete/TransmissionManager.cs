using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TransmissionManager : ITransmissionService
    {
        private ITransmissionDal _transmissionDal;
        private readonly TransmissionBusinessRules _transmissionBusinessRules;
        private readonly IMapper _mapper;

        public TransmissionManager(ITransmissionDal transmissionDal, TransmissionBusinessRules transmissionBusinessRules, IMapper mapper)
        {
            _transmissionDal = transmissionDal;
            _transmissionBusinessRules = transmissionBusinessRules;
            _mapper = mapper;
        }
            public GetTransmissionListResponse GetList(GetTransmissionListRequest request)
                    {
                        IList<Transmission> transmissionList = _transmissionDal.GetList();
                        GetTransmissionListResponse response = _mapper.Map<GetTransmissionListResponse>(transmissionList);
                        return response;
                    }
        public AddTransmissionResponse Add(AddTransmissionRequest request)
        {
            _transmissionBusinessRules.CheckIfTransmissionNameAlreadyExists(request.Name);
            Transmission transmissionToAdd = _mapper.Map<Transmission>(request); 
            _transmissionDal.Add(transmissionToAdd);
            AddTransmissionResponse response = _mapper.Map<AddTransmissionResponse>(transmissionToAdd);
            return response;
        }

        public void Update(UpdateTransmissionRequest request)
        {
            Transmission transmission = _transmissionDal.GetList().FirstOrDefault(x=>x.Id == request.Id);
            _transmissionBusinessRules.CheckIfTransmissionExists(transmission.Id);
            Transmission transmissionToUpdate = _mapper.Map<Transmission>(request);
            _transmissionDal.Update(transmissionToUpdate);
        }

        public void Delete(DeleteTransmissionRequest request)
        {
            Transmission transmission = _transmissionDal.GetList().FirstOrDefault(x => x.Id == request.Id);
            _transmissionBusinessRules.CheckIfTransmissionExists(transmission.Id);
            Transmission transmissionToDelete = _mapper.Map<Transmission>(request);
            _transmissionDal.Delete(transmissionToDelete);
        }
    }
}
