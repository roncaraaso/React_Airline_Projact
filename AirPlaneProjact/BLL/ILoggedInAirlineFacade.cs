using AirPlaneProjact.Dal;
using AirPlaneProjact.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.BLL
{
    public interface ILoggedInAirlineFacade
    {
        IList<Ticket> GetAllTickets(LoginToken<AirLineCompanyLogin> token);

        IList<Flight> GetAllFlights(LoginToken<AirLineCompanyLogin> token);

        void CancelFlight(LoginToken<AirLineCompanyLogin> token, Flight flight);

        void CreateFlight(LoginToken<AirLineCompanyLogin> token, Flight flight);

        void UpdateFlight(LoginToken<AirLineCompanyLogin> token, Flight flight);

        void ChangeMyPassword(LoginToken<AirLineCompanyLogin> token, string oldPassword, string newPassword);

        void MofidyAirlineDetails(LoginToken<AirLineCompanyLogin> token, AirlineCompanie airline);

        AirlineCompanie GetAirlineByUesrName(LoginToken<AirLineCompanyLogin> token, string name);
    }
}
