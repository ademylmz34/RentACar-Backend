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
            
            CarManager carManager = new CarManager(new EfCarDal());
            ////Car car1=new Car() { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 100, Description = "Opel" };
            ////Car car2=new Car() { Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2012, DailyPrice = 150, Description = "Renault" };
            ////Car car3=new Car() { Id = 3, BrandId = 2, ColorId = 4, ModelYear = 2013, DailyPrice = 180, Description = "Ford" };
            ////Car car4=new Car() { Id = 4, BrandId = 2, ColorId = 4, ModelYear = 2014, DailyPrice = 200, Description = "Bmw" };
            ////Car car5=new Car() { Id = 5, BrandId = 3, ColorId = 4, ModelYear = 2015, DailyPrice = 240, Description = "Mercedes" };
            Car car6=new Car() { Id = 6, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 100, Description = "A" };

            //carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Add(car3);
            //carManager.Add(car4);
            //carManager.Add(car5);

            carManager.Add(car6);

            Console.WriteLine("**********GetCarsByBrandId******************");
            foreach (var cars in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(cars.Description);
            }
            Console.WriteLine("**********GetCarsByColorId******************");
            foreach (var cars in carManager.GetCarsByColorId(4))
            {
                Console.WriteLine(cars.Description);
            }


        }
    }
}
