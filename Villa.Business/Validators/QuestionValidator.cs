using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class QuestionValidator : AbstractValidator<Quest>
    {
        public QuestionValidator()
        {
            RuleFor(x=> x.Question).NotEmpty().WithMessage("Soru boş bırakılamaz.");
            RuleFor(x=> x.Question).MinimumLength(10).WithMessage("Soru en az 10 karakterden oluşmalıdır.");
            RuleFor(x=> x.Question).MaximumLength(200).WithMessage("Soru en fazla 200 karakterden oluşmalıdır.");
            

            RuleFor(x=> x.Answer).NotEmpty().WithMessage("Cevap Boş Bırakılamaz.");
            RuleFor(x => x.Answer).MinimumLength(10).WithMessage("Cevap en az 10 karakterden oluşmalıdır.");
            RuleFor(x => x.Answer).MaximumLength(200).WithMessage("Cevap en fazla 200 karakterden oluşmalıdır.");

        }
    }
}
