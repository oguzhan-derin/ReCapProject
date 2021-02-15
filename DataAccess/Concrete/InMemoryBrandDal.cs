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
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand> {
                new Brand {BrandId=1,BrandName="Fiat" },
                new Brand {BrandId=2,BrandName="Opel" },
                new Brand { BrandId = 3, BrandName = "Audi" },
                new Brand { BrandId = 4, BrandName = "BMW" },
                new Brand { BrandId = 5, BrandName = "Porsche" },
                new Brand { BrandId = 6, BrandName = "Volvo" }
            };
        }
        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetBrandDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetBrandDetail(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetById(int brandId)
        {
            return _brands.Where(b => b.BrandId == brandId).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
        }
    }
}
