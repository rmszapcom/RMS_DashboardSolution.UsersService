﻿using FluentValidation;
using RMS_Dashboard.Core.DTO;

namespace RMS_Dashboard.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            //Email
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address format")
                ;

            //Password
            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required")
                ;
        }
    }
}
