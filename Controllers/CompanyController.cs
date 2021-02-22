using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using AirPlaneProjact;
using AirPlaneProjact.Dal;
using AirPlaneProjact.LogIn;
using WebApplication1.Controllers.Authentication;

namespace WebApplication1.Controllers
{
    [EnableCors("*", "*", "*")]
    [CommpanyAuthentication]
    public class CompanyController : ApiController
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Route("api/company/getalltickets")]
        [HttpGet]
        public IHttpActionResult GetAllTickets()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AirLineCompanyLogin> token = new LoginToken<AirLineCompanyLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                var result = fly.GetAirlineFacade(_name, _pass, out token).GetAllTickets(token);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [Route("api/company/getairlinebyusername/{name}")]
        [HttpGet]
        public IHttpActionResult GetAirlineByUserName(string name)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AirLineCompanyLogin> token = new LoginToken<AirLineCompanyLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                var result = fly.GetAirlineFacade(_name, _pass, out token).GetAirlineByUesrName(token, name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
       
            }
        }

        [Route("api/company/getallflights")]
        [HttpGet]
        public IHttpActionResult GetAllFlights()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AirLineCompanyLogin> token = new LoginToken<AirLineCompanyLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                var result = fly.GetAirlineFacade(_name, _pass, out token).GetAllFlights(token);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);

            }
        }

        [Route("api/company/cancelflight")]
        [HttpDelete]
        public IHttpActionResult CancelFlight([FromBody]Flight flight)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AirLineCompanyLogin> token = new LoginToken<AirLineCompanyLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAirlineFacade(_name, _pass, out token).CancelFlight(token, flight);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
          
            }

        }

        [Route("api/company/createflight")]
        [HttpPost]
        public IHttpActionResult CreateFlight([FromBody]Flight flight)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AirLineCompanyLogin> token = new LoginToken<AirLineCompanyLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAirlineFacade(_name, _pass, out token).CreateFlight(token, flight);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
           
            }

        }

        [Route("api/company/updateflight")]
        [HttpPut]
        public IHttpActionResult UpdateFlight([FromBody]Flight flight)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AirLineCompanyLogin> token = new LoginToken<AirLineCompanyLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAirlineFacade(_name, _pass, out token).UpdateFlight(token, flight);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
    
            }

        }

        [Route("api/company/changemypassword")]
        [HttpPost]
        public IHttpActionResult ChangeMyPassword(string oldPassword = "", string newPassword = "")
        {
            if (newPassword == "" || oldPassword == "")
            {
                return BadRequest("PassWord not given right");
            }
            else
            {
                try
                {
                    FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                    LoginToken<AirLineCompanyLogin> token = new LoginToken<AirLineCompanyLogin>();
                    string _name = Request.GetRequestContext().Principal.Identity.Name;
                    string _pass = Thread.CurrentPrincipal.Identity.Name;
                    fly.GetAirlineFacade(_name, _pass, out token).ChangeMyPassword(token, oldPassword, newPassword);
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

        [Route("api/company/mofidyairlinedetails")]
        [HttpPut]
        public IHttpActionResult MofidyAirlineDetails([FromBody] AirlineCompanie airline)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<AirLineCompanyLogin> token = new LoginToken<AirLineCompanyLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetAirlineFacade(_name, _pass, out token).MofidyAirlineDetails(token, airline);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
       
            }

        }
        [Route("api/company/GetAirlineRedis")]
        [HttpPost]
        public IHttpActionResult GetAirlineRedis([FromBody] AirlineCompanie airline)
        {
            try
            {
                string host = "LocalHost";
                string key = "key" + SetRedis.airlineNum++;
                if(SetRedis.airlineNum == 20)
                {
                    SetRedis.airlineNum = 0;
                }

                SetRedis.setToRedis(host, key, airline.ToString());

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


