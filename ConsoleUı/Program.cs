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
            //BrandTest();
           // ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine(colorManager.GetById(2).Data);

            Console.WriteLine("*******************************************************");
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
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
            var result = carManager.GetAll();
            if (result.Success==true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + " " + item.ModelYear + " " + item.BrandId + " " +
                    item.Description + " " + item.ColorId + " " + item.DailyPrice); ;
                    // Console.WriteLine(item.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
            Console.WriteLine("*******************************************************");

            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(item.BrandName);
            }
            Console.WriteLine("*******************************************************");

        }
    }
}
