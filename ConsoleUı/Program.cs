using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUı
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var item in carManager.GetCars())
            {
                Console.WriteLine(item.Id + " " + item.ModelYear + " " + item.BrandId + " " +
                    item.Description + " " + item.ColorId + " " + item.DailyPrice); ;
            }
            Console.ReadLine();
        }
    }
}
