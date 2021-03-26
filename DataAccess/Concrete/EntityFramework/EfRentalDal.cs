using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {

                var result = from c in context.Customers
                             join r in context.Rentals
                             on c.UserId equals r.CustomerId
                             join cr in context.Cars
                             on r.CarId equals cr.Id
                             join b in context.Brands
                             on cr.BrandId equals b.BrandId
                             join cl in context.Colors
                             on cr.ColorId equals cl.ColorId
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 BrandName = b.BrandName,
                                 CarName = cr.Description,
                                 ColorName = cl.ColorName,
                                 CustomerCompanyName = c.CompanyName,
                                 CustomerName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 DailyPrice = cr.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate


                             };
                return result.ToList();
            }
        }
    }
}
