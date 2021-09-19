using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception //jwt için
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//her istek için bir httpcontext oluşur. sonuçta milyonlarca istek var.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//metni senin belirttiğin karaktere göre ayırıp diziye atıyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //ServiceTool bizim injection altyapımızı okuyabilmemizi sağlaycak bir araç.

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();//o anki kullanıcının claim rollerini bul.
            foreach (var role in _roles)//bu kullanıcının rollerini gez
            {
                if (roleClaims.Contains(role))//eğer claimlerinin içinde ilgili rol varsa
                {
                    return;//methodu çalıştırmaya devam et.
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
