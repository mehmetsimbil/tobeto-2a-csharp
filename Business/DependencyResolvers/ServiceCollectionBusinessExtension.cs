using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Utilities.Security.JWT;


namespace Business.DependencyResolvers
{
    public static class ServiceCollectionBusinessExtension
    {
        public static IServiceCollection AddBusinessServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
        {
            services
            .AddScoped<IBrandService, BrandManager>()
            .AddScoped<IBrandDal, EfBrandDal>()
            .AddScoped<BrandBusinessRules>()
            .AddSingleton<IFuelService, FuelManager>()
            .AddSingleton<IFuelDal, InMemoryFuelDal>()
            .AddSingleton<FuelBusinessRules>()
            .AddSingleton<ITransmissionService, TransmissionManager>()
            .AddSingleton<ITransmissionDal, InMemoryTransmissionDal>()
            .AddSingleton<TransmissionBusinessRules>()
            .AddScoped<IModelService, ModelManager>()
            .AddScoped<IModelDal, EfModelDal>()
            .AddScoped<ModelBusinessRules>()
            .AddScoped<ICarService, CarManager>()
            .AddScoped<ICarDal, EfCarDal>()
            .AddScoped<CarBusinessRules>()
            .AddScoped<IUserService, UserManager>()
            .AddScoped<IUserDal, EfUserrDal>() 
            .AddScoped<UsersBusinessRules>()
            .AddScoped<IIndividualCustomerDal, EfIndividualCustomerDal>()
            .AddScoped<IIndividualCustomerService,IndividualCustomerManager>()
            .AddScoped<ICustomersDal,EfCustomersDal>()
            .AddScoped<ICustomerService,CustomerManager>()
            .AddScoped<CustomerBusinessRules>()
            .AddScoped<ICorporateCustomerDal,EfCorporateCustomerDal>()
            //.AddScoped<ICorporateCustomerService,CorporateCustomerManager>()
            .AddScoped<IIndividualCustomerDal,EfIndividualCustomerDal>()
            .AddScoped<IIndividualCustomerService,IndividualCustomerManager>()
            .AddScoped<IUserRoleDal,EfUserRoleDal>()
            .AddScoped<IndividualCustomerBusinessRules>()
            .AddScoped<ITokenHelper,JwtTokenHelper>()
            .AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<RentACarContext>(
             options => options.UseSqlServer(configuration.GetConnectionString("RentACarMSSQL22"))
         );
            return services;
        }
    }
}
