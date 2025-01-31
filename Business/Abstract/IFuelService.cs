﻿using Business.Requests.Brand;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFuelService
    {
        public AddFuelResponse Add(AddFuelRequest request);
        public void Update(UpdateFuelRequest request);
        public void Delete(DeleteFuelRequest request);
        public GetFuelListResponse GetList(GetFuelListRequest request);
    }
}
