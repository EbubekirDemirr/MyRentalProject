using Business.Abstract;
using Business.Constans;
using Castle.DynamicProxy.Contributors;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using Dataaccess.Abstract;
using Dataaccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.Models;
using Entities.DTOs;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerDal _customerDal;
        ICarDal _carDal;


        public RentalManager(IRentalDal rentalDal, ICustomerDal customerDal,ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _customerDal = customerDal;
            _carDal=carDal;

        }
        public IDataResult<List<RentalDetail>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetail>>(_rentalDal.GetRentalDetail());
        }
        public IResult Add(CreateRental createRental)
        {
            _customerDal.Add(new Customer
            {
                UserId = createRental.UserId,
            });
            var customer = _customerDal.Get(cu => cu.UserId == createRental.UserId);
            var rental = new Rental
            {
                CarId = createRental.CarId,
                CustomerId = customer.CustomerId,
                RentDate = createRental.RentDate,
                ReturnDate = createRental.ReturnDate,
            };    
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        public IResult IsCarAvaible(int carId)
        {
            IResult result = BusinessRules.Run(IsCarAvaibleForRent(carId));
            if (result != null)
            {
                return new ErrorResult("Araç belirtilen aralıkta uygun değil.");
            }
            return new SuccessResult("Belirtilen tarihte araç durumu müsait");
        }

        private IResult IsCarAvaibleForRent(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        public List<int> CalculateTotalPrice(DateTime rentDate, DateTime returnDate, int carId)
        {
            List<int> totalAmount = new List<int>();
            var dateDifference = (returnDate - rentDate).Days;
            //var datesOfDifference = dateDifference.Days;
            var dailyCarPrice = decimal.ToInt32(_carDal.Get(c => c.CarId == carId).DailyPrice);

            var totalPrice = dateDifference * dailyCarPrice;

            totalAmount.Add(dateDifference);
            totalAmount.Add(totalPrice);


            return totalAmount;
        }
    }
}
