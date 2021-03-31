using Business.Concrete;
using Business.Constants;
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
            //CarTest();
            //BrandTest();
            //ColorTest();
            //AddUser();
            //AddRental();
        }
        //private static void AddRental()
        //{
        //    RentalManager rentalManager = new RentalManager(new EfRentalDal());
        //    rentalManager.Add(new Rental { Id = 1, CarId = 2, CustomerId = 5, RentDate = DateTime.Now } );
        //}

        //private  static void AddUser()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(new User { Id = 7, FirstName = "Cemal", LastName = "Taşkın", Email = "cemaltaskin@gmail.com", Password = "123456" });
        //}

        //private static void ColorTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    foreach (var color in colorManager.GetAll().Data)
        //    {
        //        Console.WriteLine(color.ColorId);
        //    }
              
        //}

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in brandManager.GetAll().Data)
        //    {
        //        Console.WriteLine(brand.BrandName);
        //    }
        //}

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Add(new Car { Id = 5, BrandId = 3, ColorId = 3, ModelYear = 2021, DailyPrice = 250, Description = "Otomatik" });

        //}
    }
}
