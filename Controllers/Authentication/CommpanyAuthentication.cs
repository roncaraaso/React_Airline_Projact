using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Controllers.Authentication;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Configuration;
using AirPlaneProjact;
using AirPlaneProjact.LogIn;
using System.Security.Principal;
using System.Threading;


namespace WebApplication1.Controllers.Authentication
{
    public class CommpanyAuthenticationAttribute : AuthorizationFilterAttribute
    { //
        // Summary:
        //     Calls when a process requests authorization.
        //
        // Parameters:
        //   actionContext:
        //     The action context, which encapsulates information for using System.Web.Http.Filters.AuthorizationFilterAttribute.
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string x = actionContext.Request.RequestUri.Authority;

            #region Authentication
            string authenticationRequest = actionContext.Request.Headers.Authorization.Parameter;
            string deCodedAuthenticationRequest = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationRequest));
            string[] encodedAuthenticationRequest = deCodedAuthenticationRequest.Split(':');
            string userName = encodedAuthenticationRequest[0];
            string userPass = encodedAuthenticationRequest[1];
            #endregion


            FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
            LoginToken<AirLineCompanyLogin> token = new LoginToken<AirLineCompanyLogin>();
            CompanyHelperClass.userLocalHost = x;
            fly.GetAirlineFacade(userName, userPass, out token);

            if (token != null)
               {
                actionContext.Request.GetRequestContext().Principal = new GenericPrincipal(new GenericIdentity(userName), null);
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userPass), null);
                return;
               }
             else if(CompanyHelperClass.userLocalHost == x)
             {
                CompanyHelperClass.countNumOfEntries++;

                if(CompanyHelperClass.countNumOfEntries == 3)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                        $"Uesr {CompanyHelperClass.userLocalHost}is blocked");
                    return;
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    "Worng password or user name");
            }   
        }
    }
}