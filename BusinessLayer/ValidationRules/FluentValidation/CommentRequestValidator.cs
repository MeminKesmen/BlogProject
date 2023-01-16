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
    public class CommentRequestValidator : AbstractValidator<CommentRequestViewModel>
    {
        public CommentRequestValidator()
        {
            
            RuleFor(c=>c.CommentUserName).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(c => c.CommentUserName).NotNull().WithMessage("İsim boş geçilemez.");
            RuleFor(c => c.CommentUserName).MaximumLength(30).WithMessage("İsim 30 karakterden fazla olamaz");
            RuleFor(c => c.CommentTitle).NotEmpty().WithMessage("İsim boş geçilemez.");
            RuleFor(c => c.CommentTitle).NotNull().WithMessage("İsim boş geçilemez.");
            RuleFor(c => c.CommentTitle).MaximumLength(30).WithMessage("Başlık 30 karakterden fazla olamaz");
            RuleFor(c => c.CommentContent).NotEmpty().WithMessage("İçerik boş geçilemez.");
            RuleFor(c => c.CommentTitle).NotNull().WithMessage("İçerik boş geçilemez.");
            RuleFor(c => c.CommentTitle).MaximumLength(100).WithMessage("İçerik 100 karakterden fazla olamaz");

        }
    }
}
