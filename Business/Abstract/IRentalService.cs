using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Models;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetail>> GetRentalDetail();
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(CreateRental createRental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult IsCarAvaible(int carId);
        List<int> CalculateTotalPrice(DateTime rentDate, DateTime returnDate, int carId);
    }
}
