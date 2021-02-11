using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba açıklaması 2 karaktarden büyük olmalı ve fiyatı 0 TL'den büyük olmalıdır.");
            }
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<CarDetailDto> GetCarDetails()
        {
           return _carDal.GetCarDetails();
        }

        public List<Car> GetCars()
        {
            return _carDal.GetAll();
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
