using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId=1,ColorId=2,DailyPrice=175, Description="Otomatik 1.6", Id=1, ModelYear=2017},
                new Car{BrandId=2,ColorId=4,DailyPrice=200, Description="Manuel 1.3 Turbo", Id=2, ModelYear=2020},
                new Car{BrandId=3,ColorId=3,DailyPrice=315, Description="Otomatik 1.4 TSI", Id=3, ModelYear=2019},
                new Car{BrandId=1,ColorId=2,DailyPrice=175, Description="Otomatik 1.6", Id=1, ModelYear=2017},
                new Car{BrandId=4,ColorId=5,DailyPrice=325, Description="Otomatik 3.20 ", Id=4, ModelYear=2021},
                new Car{BrandId=5,ColorId=1,DailyPrice=750, Description="Otomatik 911 Turbo S", Id=5, ModelYear=2016},
                new Car{BrandId=6,ColorId=3,DailyPrice=275, Description="Otomatik V40 Cross Country", Id=6, ModelYear=2020},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.Single(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
