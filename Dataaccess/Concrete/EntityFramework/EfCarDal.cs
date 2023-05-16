using Core.DataAccess.EntityFramework;
using Dataaccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars                            
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDTO 
                             {BrandName=b.BrandName,
                              CarId=c.CarId,
                              CarName =c.CarName, };
                return result.ToList();
            }
        }
    }
}
