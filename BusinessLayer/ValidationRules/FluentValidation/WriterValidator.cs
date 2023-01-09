using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(w => w.WriterName).MinimumLength(2).WithMessage("İsim 2 karakterden fazla olmalı.");
            RuleFor(w => w.WriterName).MaximumLength(50).WithMessage("İsim 50 karakterden az olmalı.");
            RuleFor(w => w.WriterMail).NotEmpty().WithMessage("Mail boş geçilemez.");
            RuleFor(w => w.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez.");
        }
    }
}   
