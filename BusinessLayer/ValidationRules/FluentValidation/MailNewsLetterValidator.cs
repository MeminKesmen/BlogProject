using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MailNewsLetterValidator : AbstractValidator<MailNewsLetter>
    {
        public MailNewsLetterValidator()
        {
            RuleFor(m => m.Mail).NotEmpty().WithMessage("Mail boş geçilemez.");
            RuleFor(m => m.Mail).NotNull().WithMessage("Mail boş geçilemez.");
            RuleFor(m => m.Mail).MaximumLength(50).WithMessage("Mail 50 karakteri geçemez.");
        }
    }
}
