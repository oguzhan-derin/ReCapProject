﻿using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
        }

        private bool ValidatePassword(string arg)
        {
            const int min_leght = 8;
            const int max_leght = 12;
            if (arg == null) throw new ArgumentNullException();
            bool meetsLengthRequirements = arg.Length >= min_leght && arg.Length <= max_leght;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;
            if (meetsLengthRequirements)
            {
                foreach (char c in arg)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }
            bool isValid = meetsLengthRequirements
                && hasUpperCaseLetter 
                && hasLowerCaseLetter
                && hasDecimalDigit;
            return isValid;
        }
    }
}
