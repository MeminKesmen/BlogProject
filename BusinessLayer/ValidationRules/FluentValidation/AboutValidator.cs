using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class AboutValidator: AbstractValidator<About>
    {
        public AboutValidator()
        {

            RuleFor(a => a.AboutDetails).NotEmpty().WithMessage("Detay boş geçilemez.");
            RuleFor(a => a.AboutDetails).NotNull().WithMessage("Detay boş geçilemez.");
            RuleFor(a => a.AboutDetails).MaximumLength(500).WithMessage("Detay 500 karakteri geçemez.");
            
        }
    }
}
