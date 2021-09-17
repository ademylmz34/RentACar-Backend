using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //bütün methodlarımızın çatısı.
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)//buradaki invocation bizim çalıştırmak istediğimiz method.
        {
            //Methodların hepsi bu kurallardan geçicek sonra çalışacak.
            var isSuccess = true;
            OnBefore(invocation);//methodun başında çalışır.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//hata aldığında çalıştır
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//method başarılı olunca çalıştır.
                }
            }
            OnAfter(invocation);//methoddan sonra çalıştır.
        }
    }

}
