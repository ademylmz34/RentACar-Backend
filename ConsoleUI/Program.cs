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
            Console.WriteLine("**********GET CAR DETAİLS**********");
            GetCarDetails();
            Console.WriteLine("------------------------------------------------------------");
            CarTest();
            Console.WriteLine("------------------------------------------------------------");
            BrandTest();
            Console.WriteLine("------------------------------------------------------------");
            ColorTest();
            Console.WriteLine("------------------------------------------------------------");
            
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(colorManager.GetById(6).ColorName);
            Console.WriteLine("***************************");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetById(5).BrandName);
            Console.WriteLine("***************************");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetById(5).Description);
            Console.WriteLine("***************************");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            
           
        }

        private static void AddingColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color() { ColorName = "Siyah" };
            Color color2 = new Color() { ColorName = "Beyaz" };
            Color color3 = new Color() { ColorName = "Kırmızı" };
            Color color4 = new Color() { ColorName = "Yeşil" };
            Color color5 = new Color() { ColorName = "Mavi" };
            Color color6 = new Color() { ColorName = "Sarı" };
            Color color7 = new Color() { ColorName = "Pembe" };
            Color color8 = new Color() { ColorName = "Mor" };
            Color color9 = new Color() { ColorName = "Gri" };
            colorManager.Add(color1);
            colorManager.Add(color2);
            colorManager.Add(color3);
            colorManager.Add(color4);
            colorManager.Add(color5);
            colorManager.Add(color6);
            colorManager.Add(color7);
            colorManager.Add(color8);
            colorManager.Add(color9);
        }

        private static void AddingBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand() { BrandName = "AUDI" };
            Brand brand2 = new Brand() { BrandName = "BMW" };
            Brand brand3 = new Brand() { BrandName = "RENAULT" };
            Brand brand4 = new Brand() { BrandName = "MERCEDES" };
            Brand brand5 = new Brand() { BrandName = "FORD" };
            Brand brand6 = new Brand() { BrandName = "OPEL" };
            Brand brand7 = new Brand() { BrandName = "FIAT" };
            Brand brand8 = new Brand() { BrandName = "VOLKSWAGEN" };
            brandManager.Add(brand1);
            brandManager.Add(brand2);
            brandManager.Add(brand3);
            brandManager.Add(brand4);
            brandManager.Add(brand5);
            brandManager.Add(brand6);
            brandManager.Add(brand7);
            brandManager.Add(brand8);
        }

        private static void AddingCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car() { Id = 1, BrandId = 1, ColorId = 3,  ModelYear = 2010, DailyPrice = 100, Description = "AUDI A6 Full Paket Kırmızı" };
            Car car2 = new Car() { Id = 2, BrandId = 4, ColorId = 5,  ModelYear = 2012, DailyPrice = 200, Description = "MERCEDES G6 FULL Paket Mavi" };
            Car car3 = new Car() { Id = 3, BrandId = 3, ColorId = 9,  ModelYear = 2013, DailyPrice = 150, Description = "RENAULT FLUENCE Model FULL Paket Gri" };
            Car car4 = new Car() { Id = 4, BrandId = 8, ColorId = 1,  ModelYear = 2014, DailyPrice = 300, Description = "VOLKSWAGEN PASSAT FULL Paket Siyah" };
            Car car5 = new Car() { Id = 5, BrandId = 5, ColorId = 2,  ModelYear = 2015, DailyPrice = 100, Description = "FORD FOCUS Full Paket Beyaz" };
            Car car6 = new Car() { Id = 6, BrandId = 2, ColorId = 8,  ModelYear = 2010, DailyPrice = 150, Description = "BMW X6 FULL Paket Mor" };
            carManager.Update(car1);
            carManager.Update(car2);
            carManager.Update(car3);
            carManager.Update(car4);
            carManager.Update(car5);
            carManager.Update(car6);
        }
    }
}
