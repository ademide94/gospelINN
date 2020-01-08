using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
//using System.Security.Principal;
//using System.Security.Claims;

namespace GospelInnMinistry.CommonCode
{
	public class IdentityCode
	{
	}

    //public static class GenericPrincipalExtensions
    //{
    //    public static string GetFirstName(this IPrincipal user)
    //    {
    //        if (user.Identity.IsAuthenticated)
    //        {
    //            ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
    //            foreach (var claim in claimsIdentity.Claims)
    //            {
    //                if (claim.Type == "FirstName")
    //                    return claim.Value;
    //            }
    //            return "";
    //        }
    //        else
    //            return "";
    //    }
    //}

    public static class IdentityExtensions
    {
        public static string GetFirstName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci?.FindFirst("FirstName").ToString().Substring(("FirstName: ").Length);
             //   return ci.Claims.ToList().Where(m=>m.Value == "FirstName").ToString();
            }
            return null;
        }


        
              public static string GetEmail(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci?.FindFirst("Email").ToString().Substring(("Email: ").Length);
                //   return ci.Claims.ToList().Where(m=>m.Value == "FirstName").ToString();
            }
            return null;
        }

        public static string GetMobileNumber(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci?.FindFirst("MobileNumber").ToString().Substring(("MobileNumber: ").Length);
                //   return ci.Claims.ToList().Where(m=>m.Value == "FirstName").ToString();
            }
            return null;
        }

        public static string GetAddress(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci?.FindFirst("Address").ToString().Substring(("Address: ").Length);
                //   return ci.Claims.ToList().Where(m=>m.Value == "FirstName").ToString();
            }
            return null;
        }

        public static string GetLastName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci?.FindFirst("LastName").ToString().Substring(("LastName: ").Length);
                //   return ci.Claims.ToList().Where(m=>m.Value == "FirstName").ToString();
            }
            return null;
        }


    }
}