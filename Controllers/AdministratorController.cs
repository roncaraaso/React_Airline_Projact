using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using AirPlaneProjact;
using AirPlaneProjact.Dal;
using AirPlaneProjact.DAL;
using AirPlaneProjact.LogIn;
using ServiceStack.Redis;
using WebApplication1.Controllers.Authentication;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [EnableCors("*", "*", "*")]
    [AdministratorAuthentication]
    public class AdministratorController : ApiController
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Route("api/administrator/createnewairline")]
        [HttpPost]
        public IHttpActionResult CreateNewAirline([FromBody]AirlineCompanie airline)
        { string myMail = "carassowork@gmail.com";
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AdministratorLogin> token = new LoginToken<AdministratorLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAdministratorFacad(_name, _pass, out token).CreateNewAirline(token, airline);
                SendGridServ.Execute(myMail, airline._Email, airline._AirLine_Name, "Welcome to the site", "Welcome to the site");
                
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            
            }

        }
        [Route("api/administrator/updateairlinedetails")]
        [HttpPut]
        public IHttpActionResult UpdateAirlineDetails([FromBody]AirlineCompanie airline)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AdministratorLogin> token = new LoginToken<AdministratorLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAdministratorFacad(_name, _pass, out token).UpdateAirlineDetails(token, airline);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            }

        }
        [Route("api/administrator/removeairline")]
        [HttpDelete]
        public IHttpActionResult RemoveAirline([FromBody]AirlineCompanie airline)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AdministratorLogin> token = new LoginToken<AdministratorLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAdministratorFacad(_name, _pass, out token).RemoveAirline(token, airline);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
                
            }

        }
        [Route("api/administrator/createnewcustomer")]
        [HttpPost]
        public IHttpActionResult CreateNewCustomer([FromBody] Customer customer)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AdministratorLogin> token = new LoginToken<AdministratorLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAdministratorFacad(_name, _pass, out token).CreateNewCustomer(token, customer);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [Route("api/administrator/updatecustomerdetails")]
        [HttpPut]
        public IHttpActionResult UpdateCustomerDetails([FromBody] Customer customer)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AdministratorLogin> token = new LoginToken<AdministratorLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAdministratorFacad(_name, _pass, out token).UpdateCustomerDetails(token, customer);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            }

        }
        [Route("api/administrator/removecustomer")]
        [HttpDelete]
        public IHttpActionResult RemoveCustomer([FromBody]Customer customer)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AdministratorLogin> token = new LoginToken<AdministratorLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAdministratorFacad(_name, _pass, out token).RemoveCustomer(token, customer);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            }

        }
        [Route("api/administrator/createadmin")]
        [HttpPost]
        public IHttpActionResult createAdmin([FromBody]AdministratorDal admin)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AdministratorLogin> token = new LoginToken<AdministratorLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAdministratorFacad(_name, _pass, out token).createOneAdmin(token, admin);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            }

        }


        [Route("api/administrator/GetAirlineFromRedis")]
        [HttpGet]
        public IHttpActionResult GetAirlineFromRedis([FromBody]AdministratorDal admin)
        {
            try
            {
                string[] result = new string[50];
                var host = "LocalHost";
                var key = "key";
                for (int i = 0; i <50; i++)
                {
              
                    if (SetRedis.Get(host, key + i) != null)
                    {
                        result[i] = SetRedis.Get(host, key + i) + ",key :" + key + i;
                    }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [Route("api/administrator/DeleteAirlineFromRedis/{key}")]
        [HttpDelete]
        public IHttpActionResult DeleteAirlineFromRedis(string key , AirlineCompanie airline)
        {
            string myMail = "demo@gmail.com";
            try
            {
                var host = "LocalHost";

                SetRedis.Remove(host, key);
                SendGridServ.Execute(myMail, airline._Email, airline._AirLine_Name, "Email response", "Better luck next time");
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            }

        }
    }
}