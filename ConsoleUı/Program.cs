using Business.Concrete;
using Core.Entities.Concrete;
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
                    "14.Kullanıcı Silme\n" +
                    "15.Kullanıcıların Listelenmesi\n" +
                    "16.Araba Kiralama\n" +
                    "17.Araba Teslim Etme\n" +
                    "18.Araba Kiralama Listesi\n" +
                    "19.Çıkış\n" +
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
                        UserDeletion(userManager);
                        break;
                    case 15:
                        GetAllUserList(userManager);
                        break;
                    case 16:
                        GetAllCarDetails(carManager);
                        GetAllCustomerList(customerManager);
                        RentalAddition(rentalManager);
                        break;
                    case 17:
                        ReturnRental(rentalManager);
                        break;
                    case 18:
                        GetAllRentalDetailList(rentalManager);
                        break;
                    case 19:
                        cikis = false;
                        Console.WriteLine("Çıkış işlemi gerçekleşti.");
                        break;

                }
            }
        }

        private static void UserDeletion(UserManager userManager)
        {
            Console.WriteLine("Hangi Id'ye sahip kullanıcıyı silmek istiyorsunuz? ");
            int userId = Convert.ToInt32(Console.ReadLine());
            userManager.Delete(userManager.GetById(userId).Data);
        }

        private static void GetAllRentalDetailList(RentalManager rentalManager)
        {
            Console.WriteLine("Kiralanan Arabalar Listesi: \nId\tCar Name\tCustomer Name\tRent Date\tReturn Date");
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine($"{rental.RentalId}\t{rental.CarName}\t{rental.CustomerName}\t{rental.RentDate}\t{rental.ReturnDate}");
            }
        }

        private static void ReturnRental(RentalManager rentalManager)
        {
            Console.WriteLine("Kiraladığınız araba hangi Car Id'ye sahip?");
            int carId = Convert.ToInt32(Console.ReadLine());
            var returnedRental = rentalManager.GetRentalDetails(c => c.CarId == carId);
            foreach (var rental in returnedRental.Data)
            {
                rental.ReturnDate = DateTime.Now;
                Console.WriteLine(returnedRental.Message);
            }
        }

        private static void RentalAddition(RentalManager rentalManager)
        {
            Console.WriteLine("Car Id: ");
            int carIdAdd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Id: ");
            int customerIdAdd = Convert.ToInt32(Console.ReadLine());

            Rental rentalAdd = new Rental
            {
                CarId = carIdAdd,
                CustomerId = customerIdAdd,
                RentDate = DateTime.Now,
                ReturnDate = null,
            };
            Console.WriteLine(rentalManager.Add(rentalAdd).Message);
        }

        private static void CarByDailyPrice(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Minumum değer giriniz : ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Maksimum değer giriniz : ");
            int max = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\n\nGünlük fiyat aralığı {min} ile {max} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(d => d.DailyPrice >= min & d.DailyPrice <= max).Data)
            {
                Console.WriteLine($"{car.Id}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CarById(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Hangi arabayı görmek istiyorsunuz ?Lüten bir Id numarası yazınız.");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nBrand Id'si {carId} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(c => c.Id == carId).Data)
            {
                Console.WriteLine($"{car.Id}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CarListByBrand(CarManager carManager)
        {
            Console.WriteLine("Hangi markaya sahip araç görmek istiyorsunuz ?Lüten bir Id numarası yazınız.");
            int brandCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nBrand Id'si {brandCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(b => b.BrandId == brandCarList).Data)
            {
                Console.WriteLine($"{car.Id}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }
        private static void CarListByColor(CarManager carManager)
        {
            Console.WriteLine("Hangi renge sahip arabayı görmek istiyorsunuz? Lütfen bir Id numarası yazınız.");
            int colorCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nColor Id'si {colorCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(c => c.ColorId == colorCarList).Data)
            {
                Console.WriteLine($"{car.Id}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("Car Id: ");
            int carIdUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Brand Id: ");
            int brandIdUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int colorIdUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Daily Price: ");
            int dailyPriceUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Description : ");
            string descriptionUpdate = Console.ReadLine();

            Console.WriteLine("Model Year: ");
            int modelYearUpdate = Convert.ToInt32(Console.ReadLine());

            Car carUpdate = new Car { Id = carIdUpdate, BrandId = brandIdUpdate, ColorId = carIdUpdate, DailyPrice = dailyPriceUpdate, Description = descriptionUpdate, ModelYear = modelYearUpdate };
            carManager.Update(carUpdate);
        }

        private static void CarByModelYear(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Hangi model yılına sahip arabayı görmek istiyorsunuz? Lütfen yıl değeri giriniz.");
            int modelYearForCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\n Model yılı {modelYearForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(c => c.ModelYear == modelYearForCarList).Data)
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
                FirstName = userName,
                LastName = userLastName,
                Email = userMail          
                
            };
            userManager.Add(user);
        }

        private static void GetAllCustomerList(CustomerManager customerManager)
        {
            Console.WriteLine("Müşterilerin Listesi: \nId\tCustomer Id\tCustomer Name");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.UserId}\t{customer.CustomerId}\t\t{customer.CompanyName}");
            }
        }

        private static void GetAllUserList(UserManager userManager)
        {
            Console.WriteLine("Kullanıcı Listesi: \nId\tFirst Name\tLast Name\tEmail");

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t\t{user.LastName}\t\t{user.Email}");
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
            Console.WriteLine("Araba Listesi: \nId\tColor Name\tBrand Name\tModel Year");

            foreach (var cardetail in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{cardetail.Id}\t{cardetail.ColorName}\t\t{cardetail.BrandName}\t\t{cardetail.ModelYear}");
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
            Console.WriteLine("Color :");
            int colorName = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Brand :");
            int brandName = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Model Year :");
            int modelYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Daily Price:");
            int dailyPrice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Description :");
            string description = Console.ReadLine();

            Car car = new Car()
            {
                ColorId = colorName,
                BrandId = brandName,
                ModelYear = modelYear,
                DailyPrice = dailyPrice,
                Description = description
            };


        }

        private static void GetAllCar(CarManager carManager)
        {
            Console.WriteLine("Arabaların Listesi:  \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.Id}\t\t{car.ColorName}\t{car.BrandName}\t{car.ModelYear}\t{car.DailyPrice}\t{car.Descriptions}");
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
