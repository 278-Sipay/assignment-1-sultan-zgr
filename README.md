
# Sipay Bootcamp Hafta 1  📝
Person class icersindeki validation lar FluentValidation kutuphanesi kullanilarak yeniden duzenlenecek.
Controller uzerindeki POST methodu attributelar yerinde FluentValidation ile calisacak sekilde duzenlenecek. 
Odev icerisinde sadece 1 controller ve 1 method teslim edilecek. 

 
## FluentValidation nedir ? 💬
Fluent Validation, iş nesneleriniz için doğrulama kuralları oluşturmak için akıcı bir arabirim ve lambda ifadeleri kullanan küçük bir . NET doğrulama kütüphanesidir

## Data annotation yerine neden FluentValidation kütüphanesini kullanmalıyız  ?  ⚡
Data annotation sayesinde validasyon ayarlamaları yapılabilir fakat SOLID prensiplerinden Tek Sorumluluk Prensibi(Single Responsibility Principle – SRP)‘ne aykırıdır! İşte bu durumda prensibe uygun validasyonel yapılanma inşa edebilmek için tüm sorumluluğu tek bir sınıfın üstleneceği bir stratejiyi benimsememiz gerekmektedir ve bunun içinde en kullanışlı tasarıma sahip kütüphane olan FluentValidation’ı tercih etmekteyiz.


## Kullanım 👨‍💻
```bash
  dotnet add package FluentValidation.AspNetCore
```
FluentValidation kütüphanesini kullanabilmek için öncelikle ya Nuget’ten ya da yukarıdaki .NET CLI komutu aracılığıyla projenize dahil etmeniz gerekmektedir.
 “AbstractValidator” abstract classından türeyen bir sınıf oluşturmamız ve aşağıdaki gibi üzerinde işlem yapmamız yeterlidir. 
 
```c#
   public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name)
           .NotEmpty().WithMessage("Staff person name is required.")
           .Length(5, 100).WithMessage("Staff person name must be between 5 and 100 characters.");

            RuleFor(p => p.Lastname)
                .NotEmpty().WithMessage("Staff person lastname is required.")
                .Length(5, 100).WithMessage("Staff person lastname must be between 5 and 100 characters.");
        }
}
