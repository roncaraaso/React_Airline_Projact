using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AirPlaneProjact;
using AirPlaneProjact.Dal;
using AirPlaneProjact.LogIn;
using WebApplication1.Controllers.Authentication;

namespace WebApplication1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AnonymousController : ApiController
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Route("api/anonymous/getallflights")]
        [HttpGet]
        [ResponseType(typeof(IList<Flight>))]
        public IHttpActionResult GetAllFlights()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                IList<Flight> result = fly.GetAnonymousFacade().GetAllFlights();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
        
            }
        }

        [Route("api/anonymous/getallairlinecompanies")]
        [HttpGet]
        public IHttpActionResult GetAllAirlineCompanies()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                IList<AirlineCompanie> result = fly.GetAnonymousFacade().GetAllAirlineCompanies();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
           
            }
        }

        [Route("api/anonymous/getallflightsvacancy")]
        [HttpGet]
        public IHttpActionResult GetAllFlightsVacancy()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().GetAllFlightsVacancy();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
          
            }
        }

        [Route("api/anonymous/getflightbyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightById(int id)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().GetFlightById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            }

        }

        [Route("api/anonymous/getflightsbyorigincountry/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByOriginCountry(int id)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().GetFlightsByOriginCountry(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
        
            }
        }

        [Route("api/anonymous/getflightsbydestinationcountry/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByDestinationCountry(int id)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().GetFlightsByDestinationCountry(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
  
            }
        }

        
        [Route("api/anonymous/getflightsbydepatruredate/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByDepatrureDate(DateTime id )
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().GetFlightsByDepatrureDate(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
             
            }
        }

        // ask for help date time premeter is null and no accesss not allowed
        [Route("api/anonymous/getflightsbylandingdate/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByLandingDate(DateTime id)
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().GetFlightsByLandingDate(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            
            }
        }
        [Route("api/anonymous/getallcountries")]
        [HttpGet]
        public IHttpActionResult getAllCountries()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getAllCountryForSearchList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
        
            }

        }
        [Route("api/anonymous/getnamesofairplanes")]
        [HttpGet]
        public IHttpActionResult getNamesOfAirplanes()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getAllAirlineForSearchList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
        
            }
        }
        [Route("api/anonymous/getallcustomersforsearchlist")]
        [HttpGet]
        public IHttpActionResult getAllCustomersForSearchList()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getAllCustomersForSearchList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
             
            }
        }
        [Route("api/anonymous/getaccountemail")]
        [HttpGet]
        public IHttpActionResult getAccountEmail()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getEmailName();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
            
            }
        }
        //
        [Route("api/anonymous/getpasswordforadmin")]
        [HttpGet]
        public IHttpActionResult getUserPasswordForAdmin()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getUserPasswordForAdmin();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
         
            }
        }

        [Route("api/anonymous/getusernameforadmin")]
        [HttpGet]
        public IHttpActionResult getUserNameForAdmin()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getUserNameForAdmin();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
             
            }
        }
        [Route("api/anonymous/getusernameforairline")]
        [HttpGet]
        public IHttpActionResult getUserNameForAirline()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getUserNameForAirline();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
       
            }
        }
        [Route("api/anonymous/getpasswordforairline")]
        [HttpGet]
        public IHttpActionResult getPasswordForAirline()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getUserPasswordForAirline();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
          
            }
        }

        [Route("api/anonymous/getusernameforcustomer")]
        [HttpGet]
        public IHttpActionResult getUserNameForCustomer()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getUserNameForCustomer();
                return Ok(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(ex.StackTrace);
                return BadRequest(ex.Message);
       
            }
        }
        [Route("api/anonymous/getpasswordforcustomer")]
        [HttpGet]
        public IHttpActionResult getPasswordForCustomer()
        {
            try
            {
                FlyingCenterSystem fly = FlyingCenterSystem.GetInstance();
                var result = fly.GetAnonymousFacade().getUserPasswordForCustomer();
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
