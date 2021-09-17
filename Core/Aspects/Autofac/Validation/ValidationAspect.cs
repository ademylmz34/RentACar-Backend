using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception//validationaspect in bir interception olduğunu söyliyoruz ve kalıtım yapıyoryz.
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//bana validator tipi ver diyor. attribute da nesneyi type ile tanımlamalıyız.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//eğer gönderilen tip bir IValidator değilse(AbstractValidator bir IValidator dır.) hata fırlat.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //reflection. Activator.CreateInstance Çalışma anında ProductValidator ın ınstance ını oluştur diyor.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //productValidator un baseType ını yani AbstractValidator u bul ve onun generic argumanlarından ilkini bul.

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //invocation.Arguments -> method un parametrelerine bak ve entityType a denk gelen yani (product) bul. birden fazla parametre de olabilir.
            foreach (var entity in entities)//ve herbirini tek tek gez.
            {
                ValidationTool.Validate(validator, entity);//ve validationtool u kullanarak validate et.
            }
        }
    }
}
