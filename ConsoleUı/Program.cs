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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            bool cikis = true;

            while (cikis)
            {
                Console.WriteLine(
                    "Rent A Car \n---------------------------------------------------------------" +
                    "\n\n1.Araba Ekleme\n" +
                    "2.Araba Silme\n" +
                    "3.Araba Güncelleme\n" +
                    "4.Arabaların Listelenmesi\n" +
                    "5.Arabaların detaylı bir şekilde Listelenmesi\n" +
                    "6.Arabaların Marka Id'sine göre Listelenmesi\n" +
                    "7.Arabaların Renk Id'sine göre Listelenmesi\n" +
                    "8.Araba Id'sine göre Listeleme\n" +
                    "9.Arabaların fiyat aralığına göre Listelenmesi\n" +
                    "10.Arabaların model yılına göre Listelenmesi\n" +
                    "11.Müşteri Ekleme\n" +
                    "12.Müşterilerin Listelenmesi\n" +
                    "13.Kullanıcı Ekleme\n" +
                    "14.Kullanıcıların Listelenmesi\n" +
                    "15.Araba Kiralama\n" +
                    "16.Araba Teslim Etme\n" +
                    "17.Araba Kiralama Listesi\n" +
                    "18.Çıkış\n" +
                    "Yukarıdakilerden hangi işlemi gerçekleştirmek istiyorsunuz ?"
                    );

                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n---------------------------------------------------------------\n");
                switch (number)
                {
                    case 1:
                        CarAddition(carManager, brandManager, colorManager);
                        break;
                    case 2:
                        GetAllCarDetails(carManager);
                        CarDeletion(carManager);
                        break;
                    case 3:
                        GetAllCarDetails(carManager);
                        CarUpdate(carManager);
                        break;
                    case 4:
                        GetAllCar(carManager);
                        break;
                    case 5:
                        GetAllCarDetails(carManager);
                        break;
                    case 6:
                        GetAllBrand(brandManager);
                        CarListByBrand(carManager);
                        break;
                    case 7:
                        GetAllColor(colorManager);
                        CarListByColor(carManager);
                        break;
                    case 8:
                        GetAllCarDetails(carManager);
                        CarById(carManager, brandManager, colorManager);
                        break;
                    case 9:
                        CarByDailyPrice(carManager, brandManager, colorManager);
                        break;
                    case 10:
                        GetAllCarDetails(carManager);
                        CarByModelYear(carManager, brandManager, colorManager);
                        break;
                    case 11:
                        GetAllUserList(userManager);
                        CustomerAddition(customerManager);
                        break;
                    case 12:
                        GetAllCustomerList(customerManager);
                        break;
                    case 13:
                        UserAddition(userManager);
                        break;
                    case 14:
                        GetAllUserList(userManager);
                        break;
                    case 15:
                        GetAllCarDetails(carManager);
                        GetAllCustomerList(customerManager);
                        RentalAddition(rentalManager);
                        break;
                    case 16:
                        ReturnRental(rentalManager);
                        break;
                    case 17:
                        GetAllRentalDetailList(rentalManager);
                        break;
                    case 18:
                        cikis = false;
                        Console.WriteLine("Çıkış işlemi gerçekleşti.");
                        break;

                }
            }
        }

        private static void CarByModelYear(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Hangi model yılına sahip arabayı görmek istiyorsunuz? Lütfen yıl değeri giriniz.");
            string modelYearForCarList = Console.ReadLine();
            Console.WriteLine($"\n\nColor Id'si {modelYearForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(c=>c.ModelYear.ToString()==modelYearForCarList).Data)
            {
                Console.WriteLine($"{car.Id}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CustomerAddition(CustomerManager customerManager)
        {
            Console.WriteLine("First Name: ");
            string companyName = Console.ReadLine();

            Customer customer = new Customer
            {
                CompanyName = companyName
            };
            customerManager.Add(customer);
        }

        private static void UserAddition(UserManager userManager)
        {
            Console.WriteLine("First Name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string userLastName = Console.ReadLine();
            Console.WriteLine("Email: ");
            string userMail = Console.ReadLine();
            Console.WriteLine("Password: ");
            string userPassword = Console.ReadLine();

            User user = new User
            { 
                FirstName=userName,
                LastName=userLastName,
                Email=userMail,
                Password=userPassword
            };
            userManager.Add(user);
        }

        private static void GetAllCustomerList(CustomerManager customerManager)
        {
            Console.WriteLine("Müşterilerin Listesi: \nId\tKullanıcı Id\tCustomer Name");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.UserId}\t{customer.CompanyName}");
            }
        }

        private static void GetAllUserList(UserManager userManager)
        {
            Console.WriteLine("Kullanıcı Listesi: \nId\tFirst Name\tLast Name\tEmail\tPassword");

            foreach (var user in userManager.GetAll().Data) 
            {
                Console.WriteLine($"{user.UserId}\t{user.FirstName}\t{user.LastName}\t{user.Email}");
            }
        }

        private static void CarDeletion(CarManager carManager)
        {
            Console.WriteLine("Hangi Id'ye sahip arabayı silmek istiyorsunuz? ");
            int carIdForDelete = Convert.ToInt32(Console.ReadLine());
            carManager.Delete(carManager.GetById(carIdForDelete).Data);

        }

        private static void GetAllCarDetails(CarManager carManager)
        {
            foreach (var cardetail in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{cardetail.Id}\t\t{cardetail.ColorName}\t{cardetail.BrandName}");
            }
        }

        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.ColorId}\t {color.ColorName}");
            }
        }

        private static void CarAddition(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Color List");
            GetAllColor(colorManager);

            Console.WriteLine("Brand List");
            GetAllBrand(brandManager);

            Console.WriteLine("Car List");
            GetAllCar(carManager);

        }

        private static void GetAllCar(CarManager carManager)
        {
            Console.WriteLine("Arabaların Listesi:  \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id}\t\t{car.ColorId}\t{car.BrandId}\t{car.ModelYear}\t{car.DailyPrice}\t{car.Description}");
            }
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.BrandId}\t{brand.BrandName}");
            }
        }
    }
}
