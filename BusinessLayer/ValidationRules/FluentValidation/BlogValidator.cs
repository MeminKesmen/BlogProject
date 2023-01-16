using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.BlogTitle).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(b => b.BlogTitle).NotNull().WithMessage("Başlık boş geçilemez!");
            RuleFor(b => b.BlogTitle).MaximumLength(150).WithMessage("Başlık 150 karakterden az olmalı!");
            RuleFor(b => b.BlogTitle).MinimumLength(5).WithMessage("Başlık 5 karakterden fazla olmalı!");
            RuleFor(b => b.BlogContent).NotEmpty().WithMessage("İçerik boş geçilemez!");
            RuleFor(b => b.BlogContent).NotNull().WithMessage("İçerik boş geçilemez!");
            RuleFor(b => b.BlogContent).MaximumLength(2000).WithMessage("İçerik 2000 karakterden az olmalı!");
            RuleFor(b => b.BlogImage).NotEmpty().WithMessage("Görsel boş geçilemez!");

        }
    }
}
