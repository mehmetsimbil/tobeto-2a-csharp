using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class ModelBusinessRules
    {
        private readonly IModelDal _modelDal;

        public ModelBusinessRules(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public void CheckModelNameCharacterNotEnough(string modelName)
        {
            if (modelName.Length <= 2)
            {
                throw new Exception("Model name not enough.");
            }
        }
        public void CheckModelDailyPrice(double modelPrice)
        {
            if(modelPrice <= 0)
            {
                throw new Exception("Model price not under zero.");
            }
        }
    }
}
