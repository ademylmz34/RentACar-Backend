using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (MyDatabaseContext context=new MyDatabaseContext())
            {
                var result = from r in context.Rentals
                             join cr in context.Cars
                             on r.CarId equals cr.Id
                             join cs in context.Customers
                             on r.CustomerId equals cs.Id
                             join br in context.Brands
                             on cr.BrandId equals br.Id
                             join u in context.Users
                             on cs.UserId equals u.Id
                             select new RentalDetailDto { Id = r.Id, BrandName = br.BrandName, CustomerFullName = u.FirstName + " "
                             + u.LastName, CompanyName = cs.CompanyName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();



            }
        }
    }
}
