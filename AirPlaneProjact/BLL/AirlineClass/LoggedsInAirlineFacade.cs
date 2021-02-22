using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;
using AirPlaneProjact.LogIn;

namespace AirPlaneProjact.BLL.Airline
{
    public class LoggedsInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {/// <summary>
     /// This class handle connecttion to Dao  Airline functions
     /// </summary>
     /// <param name="token"></param>
     /// <param name="flight"></param>
        public void CancelFlight(LoginToken<AirLineCompanyLogin> token, Flight flight)
        {
            if (token.User.GetAirLineCompanyr()) { _flightDAO.Remove(flight); }
        }

        public void ChangeMyPassword(LoginToken<AirLineCompanyLogin> token, string oldPassword, string newPassword)
        {
            if (token.User.GetAirLineCompanyr())
            {
                _airlineDAO.ChangePassword(oldPassword, newPassword);
            }
        }

        public void CreateFlight(LoginToken<AirLineCompanyLogin> token, Flight flight)
        {
            if (token.User.GetAirLineCompanyr()) { _flightDAO.Add(flight); }
        }

        public IList<Flight> GetAllFlights(LoginToken<AirLineCompanyLogin> token)
        {
            List<Flight> list = new List<Flight>();
            if (token.User.GetAirLineCompanyr())
            {
                list = (List<Flight>)_flightDAO.GetAll();
                return list;
            }
            else
                return null;
        }

        public IList<Ticket> GetAllTickets(LoginToken<AirLineCompanyLogin> token)
        {
            IList<Ticket> list = new List<Ticket>();
            if (token.User.GetAirLineCompanyr())
            {
                list = _ticketDAO.GetAll();
                return list;
            }
            else
                return null;
        }

        public void MofidyAirlineDetails(LoginToken<AirLineCompanyLogin> token, AirlineCompanie airline)
        {
            if (token.User.GetAirLineCompanyr()) { _airlineDAO.Update(airline); }
        }

        public void UpdateFlight(LoginToken<AirLineCompanyLogin> token, Flight flight)
        {
            if (token.User.GetAirLineCompanyr()) { _flightDAO.Update(flight); }
        }

        public AirlineCompanie GetAirlineByUesrName(LoginToken<AirLineCompanyLogin> token, string name)
        {
            AirlineCompanie airline = new AirlineCompanie();
            if (token.User.GetAirLineCompanyr()) { return airline = _airlineDAO.GetAirlineByUserName(name); }
            return null;
        }
    }
}
