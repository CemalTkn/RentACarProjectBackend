
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }






        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            //İş Kuralları; Kurallar Şu An Geçersiz
            IResult result=  BusinessRules.Run(CheckIfCarNameExists(car.Description),
                CheckIfCarCountOfRentalCorrect(car.Id));

            if (result !=null)
            {
                return result;
            }

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);

        }





        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == brandId));

        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarAdded);
        }








        //İş Kuralları Kurallar Şu Anlık Yanlış

        private IResult CheckIfCarCountOfRentalCorrect(int rentalId)
        {
            var result = _carDal.GetAll(c => c.Id == rentalId).Count;
            if (result>=15)
            {
                return new ErrorResult(Messages.CarCountOfRentalError);
            }
            return new SuccessResult();
        }


        private IResult CheckIfCarNameExists(string description)
        {
            var result = _carDal.GetAll(c => c.Description == description).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarCountOfRentalError);
            }
            return new SuccessResult();
        }
    }

}
