using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Customer;
using Business.Requests.Customer;
using Business.Responses.Customer;
using Core.CrossCuttingConcerns.Validation.FluentValidaton;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomersDal _customersDal;
        private readonly CustomerBusinessRules _customersBusinessRules;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomersDal customersDal, CustomerBusinessRules customersBusinessRules, IMapper mapper)
        {
            _customersDal = customersDal;
            _customersBusinessRules = customersBusinessRules;
            _mapper = mapper;
        }

        public AddCustomerResponse Add(AddCustomerRequest request)
        {
            ValidationTool.Validate(new AddCustomerRequestValidator(), request);
            _customersBusinessRules.CheckIfCustomerNameExists(request.FirstName, request.LastName);
            var customerToAdd = _mapper.Map<Customers>(request);
            Customers addedCustomer=_customersDal.Add(customerToAdd);
            var response = _mapper.Map<AddCustomerResponse>(addedCustomer);
            return response;
        }

        public DeleteCustomerResponse Delete(DeleteCustomerRequest request)
        {
            Customers? customerToDelete = _customersDal.Get(predicate: customer => customer.Id == request.Id);
            _customersBusinessRules.CheckIfCustomerExists(customerToDelete);
            Customers deletedCustomer = _customersDal.Delete(customerToDelete!);
            var response = _mapper.Map<DeleteCustomerResponse>(deletedCustomer);
            return response;
        }

        public GetCustomerListResponse GetList(GetCustomerListRequest request)
        {
            IList<Customers> customersList = _customersDal.GetList();
            GetCustomerListResponse response = _mapper.Map<GetCustomerListResponse>(customersList);
            return response;
        }

        public UpdateCustomerResponse Update(UpdateCustomerRequest request)
        {
            Customers? customerToUpdate = _customersDal.Get(predicate: customer => customer.Id == request.Id);
            _customersBusinessRules.CheckIfCustomerExists(customerToUpdate);
            customerToUpdate = _mapper.Map(request, customerToUpdate);
            Customers updatedCustomer = _customersDal.Update(customerToUpdate!);
            var response = _mapper.Map<UpdateCustomerResponse>(updatedCustomer);
            return response;

        }
    }
}
