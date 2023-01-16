using BusinessLayer.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MessageRequestValidator : AbstractValidator<MessageRequest>
    {

        public MessageRequestValidator()
        {
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage("Alıcı mail boş geçilemez.");
            RuleFor(m => m.ReceiverMail).NotNull().WithMessage("Alıcı mail boş geçilemez.");
            RuleFor(m => m.ReceiverMail).MaximumLength(50).WithMessage("Alıcı mail 50 karakteri geçemez.");
            RuleFor(m => m.Subject).NotEmpty().WithMessage("Konu mail boş geçilemez.");
            RuleFor(m => m.Subject).NotNull().WithMessage("Konu mail boş geçilemez.");
            RuleFor(m => m.Subject).MaximumLength(50).WithMessage("Konu mail 50 karakteri geçemez.");
            RuleFor(m => m.MessageDetails).NotEmpty().WithMessage("Mesaj mail boş geçilemez.");
            RuleFor(m => m.MessageDetails).NotNull().WithMessage("Mesaj mail boş geçilemez.");
            RuleFor(m => m.MessageDetails).MaximumLength(200).WithMessage("Mesaj mail 200 karakteri geçemez.");
        }
    }
}
