using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using AirPlaneProjact.LogIn;
using AirPlaneProjact;
using System.Security.Principal;
using System.Threading;

namespace WebApplication1.Controllers.Authentication
{
    public class CustomerAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string localHostCorrentString = actionContext.Request.RequestUri.Authority;
            // validaition when for requestes 
           /* if (CustomerHelperClass.customerTimeForCount <= CustomerHelperClass.customerDateTimePlus45Sec &&
                CustomerHelperClass.userLocalHost == localHostCorrentString && CustomerHelperClass.countNumOfEntries % 2 == 0)
                {
                CustomerHelperClass.customerTimeForCount = DateTime.Now;
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                $"Uesr {CustomerHelperClass.userLocalHost} is blocked for {CustomerHelperClass.customerDateTimePlus45Sec  - DateTime.Now } secoundes");
                return;
            }*/
            #region Authentication check for password and uesr name
            string authenticationRequest = actionContext.Request.Headers.Authorization.Parameter;
            string encodingAuthenticationRequest = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationRequest));

            string[] encodedAuthenticationRequest = encodingAuthenticationRequest.Split(':');
            string userName = encodedAuthenticationRequest[0];
            string userPass = encodedAuthenticationRequest[1];
            #endregion


            FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
            LoginToken<CustomerLogin> token = new LoginToken<CustomerLogin>();
            CustomerHelperClass.userLocalHost = localHostCorrentString;
            fly.GetCustomerFacade(userName, userPass, out token);

            if (token != null)
                {
                    actionContext.Request.GetRequestContext().Principal = new GenericPrincipal(new GenericIdentity(userName), null);
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userPass), null);
                    return;
                }

            if (CustomerHelperClass.userLocalHost == localHostCorrentString)
            {
                CustomerHelperClass.countNumOfEntries++;

                if (CustomerHelperClass.countNumOfEntries % 2 == 0)
                {
                    CustomerHelperClass.customerTimeForCount = DateTime.Now;
                    CustomerHelperClass.customerDateTimePlus45Sec = CustomerHelperClass.customerTimeForCount.AddSeconds(45);
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                        $"Uesr {CustomerHelperClass.userLocalHost} is blocked");
                    return;
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                     "Worng password or user name");
            }
        }
    }
}