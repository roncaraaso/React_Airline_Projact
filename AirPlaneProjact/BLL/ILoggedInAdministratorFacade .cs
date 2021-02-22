using AirPlaneProjact.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;
using AirPlaneProjact.DAL;

namespace AirPlaneProjact.BLL
{
    public interface ILoggedInAdministratorFacade 
    {
        void CreateNewAirline(LoginToken<AdministratorLogin> token, AirlineCompanie airline);

        void UpdateAirlineDetails(LoginToken<AdministratorLogin> token, AirlineCompanie customer);

        void RemoveAirline(LoginToken<AdministratorLogin> token, AirlineCompanie airline);

        void CreateNewCustomer(LoginToken<AdministratorLogin> token, Dal.Customer customer);

        void UpdateCustomerDetails(LoginToken<AdministratorLogin> token, Dal.Customer customer);

        void RemoveCustomer(LoginToken<AdministratorLogin> token, Dal.Customer customer);
    }
}
