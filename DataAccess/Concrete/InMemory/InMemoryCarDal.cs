using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=150, Description="M", ModelYear=2020},
                new Car{CarId=2, BrandId=1, ColorId=1, DailyPrice=170, Description="o", ModelYear=2021},
                new Car{CarId=3, BrandId=2, ColorId=1, DailyPrice=200, Description="o", ModelYear=2020},
                new Car{CarId=4, BrandId=3, ColorId=2, DailyPrice=130, Description="M", ModelYear=2020},
                new Car{CarId=5, BrandId=3, ColorId=3, DailyPrice=250, Description="o", ModelYear=2021},
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(p => p.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAllByCarId(int carId)
        {
            return _car;
        }

        public void Update(Car car)
        {
            Car carToUpdte = _car.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdte.CarId = car.CarId;
            carToUpdte.BrandId = car.BrandId;
            carToUpdte.ColorId = car.ColorId;
            carToUpdte.DailyPrice = car.DailyPrice;
            carToUpdte.Description = car.Description;
            carToUpdte.ModelYear = car.ModelYear;
        }
    }
}
