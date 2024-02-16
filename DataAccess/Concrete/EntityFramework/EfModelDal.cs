using Core.DataAccess.EntityFramework;
using Core.DataAccess.InMemory;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : EfEntityRepositoryBase<Model, int, RentACarContext>, IModelDal
    {
        public EfModelDal(RentACarContext context) : base(context)
        {
        }
    }
}
