using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(2);


            RuleFor(u => u.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(2);


            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(Contain).WithMessage("Your Mail address must Contain '@' character")
                .EmailAddress();


        }

        private bool Contain(string arg)
        {
            if (arg.Contains("@"))
            {
                return true;
            }

            return false;
        }
    }
}
