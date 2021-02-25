using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car()
            {
                Id = 4,
                BrandId = 2,
                ColorId = 5,
                DailyPrice = 270,
                Description = "Otomatik",
                ModelYear = 2021
            };
            carManager.Add(car);
        }
    }
}
