using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
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
    [CustomerAuthentication]
    public class CustomerController : ApiController
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Route("api/customer/updateticket")]
        [HttpPut]
        public IHttpActionResult updateTicket([FromBody] Flight flight)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<CustomerLogin> token = new LoginToken<CustomerLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetCustomerFacade(_name, _pass, out token).updateTicket(token, flight);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
           
            }
        }
        [Route("api/customer/getallmyflights")]
        [HttpGet]
        public IHttpActionResult GetAllMyFlights()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<CustomerLogin> token = new LoginToken<CustomerLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                var result = fly.GetCustomerFacade(_name, _pass, out token).GetAllMyFlights(token);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
        
            }

        }
        [Route("api/customer/purchaseticket")]
        [HttpPost]
        public IHttpActionResult PurchaseTicket([FromBody]Ticket ticket)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<CustomerLogin> token = new LoginToken<CustomerLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetCustomerFacade(_name, _pass, out token).PurchaseTicket(token, ticket);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
     
            }
        }

        [Route("api/customer/cancelticket")]
        [HttpDelete]
        public IHttpActionResult CancelTicket([FromBody]Ticket ticket)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<CustomerLogin> token = new LoginToken<CustomerLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetCustomerFacade(_name, _pass, out token).CancelTicket(token, ticket);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
    
            }
        }

        [Route("api/customer/getcustomerbyuesrname/{name}")]
        [HttpGet]
        public IHttpActionResult getCustomerByUesrName(string name)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<CustomerLogin> token = new LoginToken<CustomerLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                var result = fly.GetCustomerFacade(_name, _pass, out token).getUserNamecustomer(token, name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
      
            }
        }
        [Route("api/customer/updateonecustomer")]
        [HttpPut]
        public IHttpActionResult updateOneCustomer([FromBody] Customer cast )
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<CustomerLogin> token = new LoginToken<CustomerLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                fly.GetCustomerFacade(_name, _pass, out token).updateOneCustomer(token, cast);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
 
            }
        }
        [Route("api/customer/getalltickets")]
        [HttpGet]
        public IHttpActionResult getAllTickets([FromBody] Ticket tic)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                LoginToken<CustomerLogin> token = new LoginToken<CustomerLogin>();
                string _name = Request.GetRequestContext().Principal.Identity.Name;
                string _pass = Thread.CurrentPrincipal.Identity.Name;
                var result = fly.GetCustomerFacade(_name, _pass, out token).GetTicket(token, tic);
                return Ok(result);
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
