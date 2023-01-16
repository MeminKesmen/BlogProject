using BusinessLayer.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogCreateValidator: AbstractValidator<BlogCreateViewModel>
    {
        public BlogCreateValidator()
        {
            RuleFor(b=>b.BlogTitle).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(b=>b.BlogTitle).NotNull().WithMessage("Başlık boş geçilemez.");
            RuleFor(b=>b.BlogTitle).MaximumLength(50).WithMessage("Başlık 50 karakteri geçemez.");
            RuleFor(b => b.BlogContent).NotEmpty().WithMessage("İçerik boş geçilemez.");
            RuleFor(b => b.BlogContent).NotNull().WithMessage("İçerik boş geçilemez.");
            RuleFor(b=>b.BlogContent).MaximumLength(2000).WithMessage("İçerik 20000 karakteri geçemez.");
            RuleFor(b => b.CategoryId).GreaterThanOrEqualTo(1).WithMessage("Kategori seçiniz");
        }
    }
}
