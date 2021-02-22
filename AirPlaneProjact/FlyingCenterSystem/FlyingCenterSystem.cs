using AirPlaneProjact.BLL;
using AirPlaneProjact.BLL.Airline;
using AirPlaneProjact.BLL.Customer;
using AirPlaneProjact.DAL;
using AirPlaneProjact.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact
{
    public class FlyingCenterSystem
    {
        /// <summary>
        /// This class handle connecttion to Facade  on Bll functions with singlton pattern
        /// </summary>
        private static object key = new object();
        private static FlyingCenterSystem _inctance;
   
        private FlyingCenterSystem()
        {

        }
      
        public static FlyingCenterSystem GetInstance()
        {
            if (_inctance == null)
            {
                lock (key)
                {
                    if(_inctance == null)
                    {
                        _inctance = new FlyingCenterSystem();
                        return _inctance;
                    }
                }
            }
            return _inctance;
        }
        
        public AnonymousUserFacade GetAnonymousFacade()
        {
            try
            {
                AnonymousUserFacade facade = new AnonymousUserFacade();
                return facade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoggedInAdministratorFacad GetAdministratorFacad(string Name, string Pass , out LoginToken<AdministratorLogin> token)
        {
            try
            {
                LoginService _log = new LoginService();
                LoggedInAdministratorFacad facade = new LoggedInAdministratorFacad();
                if (_log.TryAdminLogin(Name, Pass, out token) == true)
                {
                    return facade;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoggedsInAirlineFacade GetAirlineFacade(string Name, string Pass,out LoginToken<AirLineCompanyLogin> token)
        {
            try
            {
                LoginService _log = new LoginService();
                token = new LoginToken<AirLineCompanyLogin>();
                LoggedsInAirlineFacade facade = new LoggedsInAirlineFacade();
                if (_log.TryArilineLogin(Name, Pass, out token) == true)
                {
                    return facade;
                }
                return null;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public LoggedInCustomerFacade GetCustomerFacade(string Name, string Pass ,out LoginToken<CustomerLogin> token)
        {
            try
            {
                LoginService _log = new LoginService();
                token = new LoginToken<CustomerLogin>();
                LoggedInCustomerFacade facade = new LoggedInCustomerFacade();
                if (_log.TryCustomerLogin(Name, Pass, out token) == true)
                {
                    return facade;
                }
                return null;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}