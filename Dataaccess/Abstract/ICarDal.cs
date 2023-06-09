using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        List<CarDetailDTO> GetCarDetails();
        List<CarDetailDTO> GetCarDetailByCarId(int carId);
        List<CarDetailDTO> GetCarByBrandIdAndColorId(int brandId, int colorId);
        List<CarDetailWithImage> GetCarDetailWithImagesByCarId(int carId);
    }
}
