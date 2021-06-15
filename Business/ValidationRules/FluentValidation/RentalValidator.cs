using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.RentDate)
                .Cascade(CascadeMode.Continue)
                .Must(BeValidDate).WithMessage("Invalid Date Of Rent")
                .NotEmpty();
        }

        private bool BeValidDate(DateTime date)
        {
            int CurrentYear = DateTime.Now.Year;
            int DateOfRentYear = date.Year;

            if (DateOfRentYear <= CurrentYear && DateOfRentYear > (CurrentYear - 120))
            {
                return true;
            }

            return false;
        }
    }
}
