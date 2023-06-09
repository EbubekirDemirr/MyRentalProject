using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Dataaccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
       
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
           _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }



        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId == carId));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetailByCarId(carId));
        }

        public IDataResult<List<CarDetailDTO>> GetCarByBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarByBrandIdAndColorId(brandId,colorId));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails());
        }


        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CarDetailWithImage>> GetCarDetailWithImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailWithImage>>(_carDal.GetCarDetailWithImagesByCarId(carId));
        }
    }
}
