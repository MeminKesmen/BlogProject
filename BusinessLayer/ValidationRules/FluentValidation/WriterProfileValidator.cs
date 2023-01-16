using BusinessLayer.ViewModels;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterProfileValidator:AbstractValidator<WriterProfile>
    {
        public WriterProfileValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(w => w.WriterName).MinimumLength(2).WithMessage("İsim 2 karakterden fazla olmalı.");
            RuleFor(w => w.WriterName).MaximumLength(30).WithMessage("İsim 30 karakterden az olmalı.");
            RuleFor(w => w.WriterMail).NotEmpty().WithMessage("Mail boş geçilemez.");
            RuleFor(w => w.WriterMail).NotNull().WithMessage("Mail boş geçilemez.");
            RuleFor(w => w.WriterMail).MaximumLength(50).WithMessage("Mail 30 karakterden az olmalı.");
            RuleFor(w => w.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(w => w.WriterPassword).MinimumLength(8).WithMessage("Şifre 8 karakterden az olamaz.");
            RuleFor(w => w.WriterPassword).MaximumLength(20).WithMessage("Şifre 20 karakterden az olmalı.");
            RuleFor(w => w.WriterAbout).MaximumLength(1000).WithMessage("Hakkımda 1000 karakterden az olmalı.");
        }
    }
}   
