using BusinessLayer.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Mail).NotEmpty().WithMessage("Mail boş geçilemez!");
            RuleFor(l => l.Mail).NotNull().WithMessage("Mail boş geçilemez!");
            RuleFor(l => l.Password).NotEmpty().WithMessage("Şifre boş geçilemez!");
            RuleFor(l => l.Password).NotNull().WithMessage("Şifre boş geçilemez!");
        }
    }
}
