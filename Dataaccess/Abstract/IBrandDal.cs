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
    public interface IBrandDal: IEntityRepository<Brand>
    {
        List<CarDetailDTO> GetCarByBrandId(int brandId);
    }
}
