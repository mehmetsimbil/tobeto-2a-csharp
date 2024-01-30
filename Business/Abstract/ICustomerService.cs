using Business.Requests.Customer;
using Business.Responses.Customer;



namespace Business.Abstract
{
    public interface ICustomerService
    {
        public GetCustomerListResponse GetList(GetCustomerListRequest request);
        public AddCustomerResponse Add(AddCustomerRequest request);
        public UpdateCustomerResponse Update(UpdateCustomerRequest request);
        public DeleteCustomerResponse Delete(DeleteCustomerRequest request);
    }
}
