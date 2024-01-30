using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.CorporateCustomer;
using Business.Requests.ComporateCustomer;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Core.CrossCuttingConcerns.Validation.FluentValidaton;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class CorporateCustomerManager : ICorporateCustomerService
    {
        private readonly ICorporateCustomerDal _corporateCustomerDal;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly IMapper _mapper;

        public CorporateCustomerManager(ICorporateCustomerDal corporateCustomerDal, 
            CorporateCustomerBusinessRules corporateCustomerBusinessRules,
            IMapper mapper)
        {
            _corporateCustomerDal = corporateCustomerDal;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _mapper = mapper;
        }

        public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request)
        {
            ValidationTool.Validate(new AddCorporateCustomerRequestValidator(), request);
            _corporateCustomerBusinessRules.CheckIfCorporateCustomerNameExists(request.CompanyName);
            var corporateCustomerToAdd = _mapper.Map<CorporateCustomer>(request);
            CorporateCustomer addedCorporateCustomer = _corporateCustomerDal.Add(corporateCustomerToAdd);
            var response = _mapper.Map<AddCorporateCustomerResponse>(addedCorporateCustomer);
            return response;
        }

        public DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request)
        {
            CorporateCustomer? corporateCustomerToDelete = _corporateCustomerDal.Get(predicate: corporateCustomer => corporateCustomer.Id == request.Id);
            _corporateCustomerBusinessRules.CheckIfCorporateCustomerExists(corporateCustomerToDelete);
            CorporateCustomer deletedCorporateCustomer = _corporateCustomerDal.Delete(corporateCustomerToDelete!);
            var response = _mapper.Map<DeleteCorporateCustomerResponse>(deletedCorporateCustomer);
            return response;
        }

        public GetCorporateCustomerListResponse GetList(GetCorporateCustomerListRequest request)
        {
            IList<CorporateCustomer> corporateCustomerList = _corporateCustomerDal.GetList();
            GetCorporateCustomerListResponse response = _mapper.Map<GetCorporateCustomerListResponse>(corporateCustomerList);
            return response;
        }

        public UpdateCorporateCustomerResponse Update(UpdateCorporateCustomerRequest request)
        {
            CorporateCustomer? corporateCustomerToUpdate = _corporateCustomerDal.Get(predicate: corporateCustomer => corporateCustomer.Id == request.Id);
            _corporateCustomerBusinessRules.CheckIfCorporateCustomerExists(corporateCustomerToUpdate);
            corporateCustomerToUpdate = _mapper.Map(request, corporateCustomerToUpdate);
            CorporateCustomer updatedCorporateCustomer = _corporateCustomerDal.Update(corporateCustomerToUpdate!);
            var response = _mapper.Map<UpdateCorporateCustomerResponse>(updatedCorporateCustomer);
            return response;
        }
    }
}
