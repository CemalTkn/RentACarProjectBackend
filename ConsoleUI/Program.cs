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

            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 3, ModelYear = 2021, DailyPrice = 2500, Description = "AMGv2" });
        }
    }
}
