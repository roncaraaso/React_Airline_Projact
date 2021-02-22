using AirPlaneProjact.Dal;
using AirPlaneProjact.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.BLL
{
   public interface IAnonymousUserFacade
    {
        IList<Flight> GetAllFlights();

        IList<AirlineCompanie> GetAllAirlineCompanies();

        Dictionary<Flight, int> GetAllFlightsVacancy();

        Flight GetFlightById(int id); 
 
        IList<Flight> GetFlightsByOriginCountry(int countryCode);

        IList<Flight> GetFlightsByDestinationCountry(int countryCode);

        IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate);

        IList<Flight> GetFlightsByLandingDate(DateTime landingDate);
        
    }
}
