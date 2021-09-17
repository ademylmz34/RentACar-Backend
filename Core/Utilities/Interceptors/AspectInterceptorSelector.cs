using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //classın attribute larını oku
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name) //methodun attribute larını oku.
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes); // bunları da yukarda toList dediğimiz listenin sonuna ekle

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //ve bu attribute ların çalışma sırasını öncelik değerine göre sırala.
        }
    }

}
