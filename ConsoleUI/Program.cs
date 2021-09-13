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
            CarTest();
           
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if(result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

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
