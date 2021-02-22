using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;

namespace AirPlaneProjact.DAO
{
    public interface IFlightDAO : IBasicDB<Flight>
    {
        Dictionary<Flight, int> GetAllFlightsVacancy();

        Flight GetFlightById(int id);

        IList<Flight> GetFlightsByOriginCountry(int countryCode);

        IList<Flight> GetFlightsByDestinationCountry(int countryCode);

        IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate);

        IList<Flight> GetFlightsByLandingDate(DateTime landingDate);

        IList<Flight> GetFlightsByCustomer(Customer customer);

        void UpdateTicketsFlight(Flight t);

        void AddWpfRecored(int num);
    }
}
