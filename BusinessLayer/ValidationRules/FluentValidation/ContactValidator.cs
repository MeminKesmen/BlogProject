using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        
        public ContactValidator()
        {
            RuleFor(c => c.ContactUserName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(c => c.ContactUserName).NotNull().WithMessage("İsim boş geçilemez.");
            RuleFor(c => c.ContactUserName).MaximumLength(50).WithMessage("İsim 50 karakteri geçemez.");
            RuleFor(c => c.ContactMail).NotEmpty().WithMessage("Mail boş geçilemez.");
            RuleFor(c => c.ContactMail).NotNull().WithMessage("Mail boş geçilemez.");
            RuleFor(c => c.ContactMail).MaximumLength(50).WithMessage("Mail 50 karakteri geçemez.");
            RuleFor(c => c.ContactSubject).NotEmpty().WithMessage("Konu boş geçilemez.");
            RuleFor(c => c.ContactSubject).NotNull().WithMessage("Konu boş geçilemez.");
            RuleFor(c => c.ContactSubject).MaximumLength(50).WithMessage("Konu 50 karakteri geçemez.");
            RuleFor(c => c.ContactMessage).NotEmpty().WithMessage("Mesaj boş geçilemez.");
            RuleFor(c => c.ContactMessage).NotNull().WithMessage("Mesaj boş geçilemez.");
            RuleFor(c => c.ContactMessage).MaximumLength(150).WithMessage("Mesaj 150 karakteri geçemez.");
        }
    }
}
