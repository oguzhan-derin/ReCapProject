using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal:IEntityRepository<Color>
    {
        List<CarDetailDto> GetColorDetail(Expression<Func<Car, bool>> filter = null);
    }
}
