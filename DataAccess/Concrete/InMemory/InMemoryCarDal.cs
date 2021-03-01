using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=150, Description="M", ModelYear=2020},
                new Car{Id=2, BrandId=1, ColorId=1, DailyPrice=170, Description="o", ModelYear=2021},
                new Car{Id=3, BrandId=2, ColorId=1, DailyPrice=200, Description="o", ModelYear=2020},
                new Car{Id=4, BrandId=3, ColorId=2, DailyPrice=130, Description="M", ModelYear=2020},
                new Car{Id=5, BrandId=3, ColorId=3, DailyPrice=250, Description="o", ModelYear=2021},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdte = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdte.Id = car.Id;
            carToUpdte.BrandId = car.BrandId;
            carToUpdte.ColorId = car.ColorId;
            carToUpdte.DailyPrice = car.DailyPrice;
            carToUpdte.Description = car.Description;
            carToUpdte.ModelYear = car.ModelYear;
        }
    }
}
