using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId+"\t"+car.ColorId+"\t"+car.ModelYear+"\t"+car.DailyPrice+"\t"+car.Description);
            }
            Console.WriteLine("*************************************************");
            foreach (var car in carManager.GetById(1))
            {
                Console.WriteLine(car.BrandId + "\t" + car.ColorId + "\t" + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Description);
            }
        }
    }
}
