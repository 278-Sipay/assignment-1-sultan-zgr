
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
 class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Lütfen adınızı boş geçmeyiniz.");
        RuleFor(c => c.Surname).NotEmpty().When(c => c.Id != 1).WithMessage("Lütfen soyadı boş geçmeyiniz.");
        RuleFor(c => c.BornDate).Must(d => d.Year <= 2000).WithMessage("Lütfen doğum tarihi 2000'den büyük olanları girmeyiniz.");
    }
}