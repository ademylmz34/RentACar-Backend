﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (MyDatabaseContext context=new MyDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join color in context.Colors on c.ColorId equals color.Id
                             select new CarDetailDto { Id = c.Id, BrandName = b.BrandName, ColorName = color.ColorName, ModelYear=c.ModelYear,
                             DailyPrice=c.DailyPrice,Description=c.Description};
                return result.ToList();
            }
        }
    }
}
