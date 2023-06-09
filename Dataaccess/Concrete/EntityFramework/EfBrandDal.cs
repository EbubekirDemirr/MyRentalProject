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
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentalContext>, IBrandDal
    {

        public List<CarDetailDTO> GetCarByBrandId(int brandId)
        {
            //CarRentalContext context2 = new CarRentalContext();
            //var test = context2.Set<Car>().AsNoTracking().Include(q => q.Brand).Include(q => q.Color).Where(q => q.BrandId == brandId).ToList();

            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             where c.BrandId == brandId

                             select new CarDetailDTO
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
        }


    }
}