using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{

    //Validation kütüphanesine dayalı olarak kısıtlama kuralları koyuyoruz.
    
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            //Büyük - küçük harf şartı vb. ekle!
            
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre değeri boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("İsmin değeri en fazla 50 karakter olabilir.");
        }
    }
}
