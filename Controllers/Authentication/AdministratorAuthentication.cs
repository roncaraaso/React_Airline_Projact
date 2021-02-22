using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using AirPlaneProjact.LogIn;
using AirPlaneProjact;
using System.Web.Http.Controllers;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Security.Principal;
using System.Threading;

namespace WebApplication1.Controllers.Authentication
{
    public class AdministratorAuthentication : AuthorizationFilterAttribute
    {//
        // Summary:
        //     Calls when a process requests authorization.
        //
        // Parameters:
        //   actionContext:
        //     The action context, which encapsulates information for using System.Web.Http.Filters.AuthorizationFilterAttribute.
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string x = actionContext.Request.RequestUri.Authority;
            string deCodedAuthentication = actionContext.Request.Headers.Authorization.Parameter;
            string enCodedAuthentication = Encoding.UTF8.GetString(Convert.FromBase64String(deCodedAuthentication));
            string[] authenticationString = enCodedAuthentication.Split(':');
            string userName = authenticationString[0];
            string userPass = authenticationString[1];

            FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
            LoginToken<AdministratorLogin> token = new LoginToken<AdministratorLogin>();
            AdminHelperClass.userLocalHost = x;
            
            fly.GetAdministratorFacad(userName, userPass, out token);
            if (token != null)
            {
                actionContext.Request.GetRequestContext().Principal = new GenericPrincipal(new GenericIdentity(userName), null);
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userPass), null);
                return;
            }else if (AdminHelperClass.userLocalHost == x)
            {
                AdminHelperClass.countNumOfEntries++;
                if(AdminHelperClass.countNumOfEntries == 3)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                        $"Uesr {CompanyHelperClass.userLocalHost}is blocked");
                    return;
                }
            }

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    "Worng password or user name");
        }
     
    }
}