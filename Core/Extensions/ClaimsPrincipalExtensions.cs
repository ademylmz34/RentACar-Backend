using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)//ClaimsPrincipal,jwt ile gelen kişinin claimlerine ulaşmaya çalışıyoruz.
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();// soru işareti null olabileceğini söyler,adam token istememiş olabilir.
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)//direkt rolleri döndürüyoruz.
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
