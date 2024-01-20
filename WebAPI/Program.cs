using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using System.Reflection;
using Business.DependencyResolvers;
using Core.CrossCuttingConcerns.Exceptions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IBrandService,BrandManager>();
//builder.Services.AddSingleton<IBrandDal,InMemoryBrandDal>();
//builder.Services.AddSingleton<BrandBusinessRules>();
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddBusinessServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGlobalExceptionBuilder();

app.Run();
