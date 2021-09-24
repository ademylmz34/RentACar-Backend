using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddingCars();
            //AddingBrands();
            //AddingColors();
            //CarTest();
            RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalmanager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental() {Id=2, CarId=1, CustomerId = 2, RentDate = DateTime.Now.Date, ReturnDate = DateTime.Parse("26/09/2021") };
            Rental rental1 = new Rental() { Id = 3, CarId = 2, CustomerId = 3, RentDate = DateTime.Now.Date, ReturnDate = DateTime.Parse("29/09/2021") };
            Rental rental2 = new Rental() { Id = 4, CarId = 3, CustomerId = 1, RentDate = DateTime.Now.Date, ReturnDate = DateTime.Parse("30/09/2021") };
            Rental rental3 = new Rental() { Id = 5, CarId = 4, CustomerId = 4, RentDate = DateTime.Now.Date, ReturnDate = DateTime.Parse("05/10/2021") };
            Rental rental4 = new Rental() { Id = 6, CarId = 5, CustomerId = 2, RentDate = DateTime.Now.Date, ReturnDate = DateTime.Parse("10/10/2021") };
            rentalmanager.Update(rental);
            rentalmanager.Update(rental1);
            rentalmanager.Update(rental2);
            rentalmanager.Update(rental3);
            rentalmanager.Update(rental4);
            Console.ReadKey();
            //var result = rentalmanager.Add(rental);
            //if (result.Success == true)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
        }

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var result = carManager.GetCarDetails();
        //    if(result.Success)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }


        //}

        private static void AddingColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color() { ColorName = "Siyah" };
            colorManager.Add(color);
        }

        private static void AddingBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand() { BrandName = "AUDI" };
            brandManager.Add(brand);
        }

        private static void AddingCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car() { BrandId = 1, ColorId = 3,  ModelYear = 2010, DailyPrice = 100, Description = "AUDI A6 Full Paket Kırmızı" };
            carManager.Add(car);
        }
    }
}
