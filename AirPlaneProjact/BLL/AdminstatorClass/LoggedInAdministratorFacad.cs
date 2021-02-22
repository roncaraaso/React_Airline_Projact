using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.LogIn;
using AirPlaneProjact.Dal;
using AirPlaneProjact.DAL;

namespace AirPlaneProjact.BLL
{
    public class LoggedInAdministratorFacad : AnonymousUserFacade, ILoggedInAdministratorFacade
    {/// <summary>
     /// This class handle connecttion to Dao  Administrator functions
     /// </summary>
     /// <param name="token"></param>
     /// <param name="airline"></param>
        public void CreateNewAirline(LoginToken<AdministratorLogin> token, AirlineCompanie airline)
        {
           { _airlineDAO.Add(airline); }
        }

        public void CreateNewCustomer(LoginToken<AdministratorLogin> token, Dal.Customer customer)
        {
            if (token.User.GetAdministrator()) { _customerDAO.Add(customer); }
        }

        public void RemoveAirline(LoginToken<AdministratorLogin> token, AirlineCompanie airline)
        {
            if (token.User.GetAdministrator()) {_airlineDAO.Remove(airline); }
        }

        public void RemoveCustomer(LoginToken<AdministratorLogin> token, Dal.Customer customer)
        {
           
            if (token.User.GetAdministrator()) { _customerDAO.Remove(customer); }
        }

        public void UpdateAirlineDetails(LoginToken<AdministratorLogin> token, AirlineCompanie airline)
        {
        if (token.User.GetAdministrator())  { _airlineDAO.Update(airline); }
        }

       

        public void UpdateCustomerDetails(LoginToken<AdministratorLogin> token, Dal.Customer customer)
        {
           if (token.User.GetAdministrator())
            {
                _customerDAO.Update(customer);
            }
       
        }

        public void createOneAdmin(LoginToken<AdministratorLogin> token, AdministratorDal admin)
        {
            if (token.User.GetAdministrator())
            {
                _administratorDAO.Add(admin);
            }

        }

    }
}
