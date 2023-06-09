using Core.DataAccess.EntityFramework;
using Dataaccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetail> GetRentalDetail()
        {
                using (CarRentalContext context = new CarRentalContext())
                {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new RentalDetail
                             {
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate,
                                 RentalId=r.RentalId,
                                 BrandId=b.BrandId,                             
                                 CarName=c.CarName,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 BrandName=b.BrandName,
                                 CustomerId=cu.CustomerId,
                                 CarId=c.CarId,
                                 UserId=u.UserId,
                                
                                 

                             };


                    return result.ToList();
                
            }
        }
    }
}
