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
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color> {
                new Color { ColorId = 1, ColorName = "Black" },
                new Color { ColorId = 2, ColorName = "White" },
                new Color { ColorId = 3, ColorName = "Red" },
                new Color { ColorId = 4, ColorName = "Blue" },
                new Color { ColorId = 5, ColorName = "Green" }

            };
        }
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetById(int colorId)
        {
            return _colors.Where(c => c.ColorId == colorId).ToList();
        }

        public List<CarDetailDto> GetColorDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetColorDetail(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
