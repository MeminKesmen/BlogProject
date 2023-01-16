using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c=>c.CategoryName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(c => c.CategoryName).NotNull().WithMessage("İsim boş geçilemez.");
            RuleFor(c => c.CategoryName).MaximumLength(30).WithMessage("Başlık 30 karakteri geçemez.");
            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez.");
            RuleFor(c => c.CategoryDescription).NotNull().WithMessage("Açıklama boş geçilemez.");
            RuleFor(c => c.CategoryDescription).MaximumLength(100).WithMessage("Başlık 100 karakteri geçemez.");
        }
    }
}
