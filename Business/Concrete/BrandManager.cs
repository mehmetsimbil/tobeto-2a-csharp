using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brand;
using Business.Responses.Brand;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private IBrandDal _brandDal;

    private readonly BrandBusinessRules _brandBusinessRules;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _brandDal = brandDal; //new InMemoryBrandDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _brandBusinessRules = brandBusinessRules;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;

    }

    public AddBrandResponse Add(AddBrandRequest request)
    {
        if(!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            throw new Exception("Giriş yapmak zorundasınız");
        }
        
        var roleClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c=>c.Value== "Admin");
        if (roleClaim.Value is not null) {
            string roleValue=roleClaim.Value;
        }
        if(roleClaim.Value is null) {
            throw new Exception("Yetkiniz yok");
        }

        
        
        // İş Kuralları
        _brandBusinessRules.CheckIfBrandNameAlreadyExist(request.Name);

        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        //Brand addedBrand =
        Brand brandToAdd = _mapper.Map<Brand>(request);
        _brandDal.Add(brandToAdd);
        AddBrandResponse response = _mapper.Map<AddBrandResponse>(brandToAdd);
        return response;
    }

    public GetBrandListResponse GetList(GetBrandListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Brand> brandList = _brandDal.GetList();
        GetBrandListResponse response = _mapper.Map<GetBrandListResponse>(brandList);
        return response;
    }

    public Brand? GetById(int id)
    {
        return _brandDal.Get(i=>i.Id == id);
    }
}
