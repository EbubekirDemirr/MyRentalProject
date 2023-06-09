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
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDTO
                             {
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarId = c.CarId,
                                 ColorId= co.ColorId,
                                 BrandId= b.BrandId,
                                 CarName = c.CarName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDTO> GetCarDetailByCarId(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             
                             where c.CarId == carId
                            
                             select new CarDetailDTO
                             {
                                 Description=c.Description,
                                 ModelYear = c.ModelYear,
                                 DailyPrice=c.DailyPrice,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId=b.BrandId,
                                 ColorId=co.ColorId,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDTO> GetCarByBrandIdAndColorId(int brandId, int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             where co.ColorId == colorId
                             where b.BrandId == brandId

                             select new CarDetailDTO
                             {
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }

           
        }
        public List<CarDetailWithImage> GetCarDetailWithImagesByCarId(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId

                             where c.CarId == carId

                             select new CarDetailWithImage
                             {
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).ToList()
                             };
                return result.ToList();
            }
        }
    }
}

