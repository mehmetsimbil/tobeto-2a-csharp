﻿using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers
{
    public static class ServiceCollectionBusinessExtension
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services
            .AddSingleton<IBrandService, BrandManager>()
            .AddSingleton<IBrandDal, InMemoryBrandDal>()
            .AddSingleton<BrandBusinessRules>()
            .AddSingleton<IFuelService, FuelManager>()
            .AddSingleton<IFuelDal, InMemoryFuelDal>()
            .AddSingleton<FuelBusinessRules>()
            .AddAutoMapper(Assembly.GetExecutingAssembly());
                
            return services;
        }
    }
}