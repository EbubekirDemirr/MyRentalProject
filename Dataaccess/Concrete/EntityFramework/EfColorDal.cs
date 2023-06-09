using Core.DataAccess.EntityFramework;
using Dataaccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarRentalContext>, IColorDal
    {
        public List<CarDetailDTO> GetCarByColorId(int colorId)
        {
            //CarRentalContext context2 = new CarRentalContext();
            //var test = context2.Set<Car>().AsNoTracking().Include(q => q.Brand).Include(q => q.Color).Where(q => q.BrandId == brandId).ToList();

            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             where c.ColorId == colorId
                             select new CarDetailDTO
                             {
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarId = c.CarId,
                                 ColorId = co.ColorId,
                                 BrandId = b.BrandId,
                                 CarName = c.CarName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

    }
}
