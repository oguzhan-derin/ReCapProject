using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUı
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            BrandTest();
            ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine(colorManager.GetById(2).ColorName);

            Console.WriteLine("*******************************************************");
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            // brandManager.Add(new Brand {BrandName="Tesla" });         

            Console.WriteLine("*******************************************************");

            //brandManager.Update(new Brand{BrandId = 1,BrandName = "Suziki"});
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetCars())
            {
                Console.WriteLine(item.Id + " " + item.ModelYear + " " + item.BrandId + " " +
                item.Description + " " + item.ColorId + " " + item.DailyPrice); ;
                // Console.WriteLine(item.BrandName);
            }
            Console.WriteLine("*******************************************************");

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.BrandName);
            }
            Console.WriteLine("*******************************************************");

        }
    }
}
