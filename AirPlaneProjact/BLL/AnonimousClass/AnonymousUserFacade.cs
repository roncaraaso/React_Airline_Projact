using System;
using System.Collections.Generic;
using AirPlaneProjact.Dal;
using AirPlaneProjact.DAO;
using AirPlaneProjact.DAO.CountryDAOMSSQL;

namespace AirPlaneProjact.BLL
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade
    {/// <summary>
     /// This class handle connecttion to Dao  Anonymous functions
     /// </summary>
        public AnonymousUserFacade()
        {
            _flightDAO = new FlightDAOMSSQL();
            _airlineDAO = new AirLineDAOMSSQL();
            _administratorDAO = new AdministratorDAOMSSQL();
            _ticketDAO = new TicketDAOMSSQL();
            _customerDAO = new CustomerDAOMMSQL();
            _countryDAO = new CountryDAOMSSQL();
        }

        public IList<Flight> GetAllFlights()
        {
         
            IList<Flight> list = new List<Flight>();
            list =_flightDAO.GetAll();
            return list;
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
         
            Dictionary<Flight, int> dic = new Dictionary<Flight, int>();
            dic = _flightDAO.GetAllFlightsVacancy();
            return dic;

        }

        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
          
            IList<Flight> list = new List<Flight>();
            list =_flightDAO.GetFlightsByDepatrureDate(departureDate);
            return list ;
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
         
            IList<Flight> list = new List<Flight>();
            list = _flightDAO.GetFlightsByDestinationCountry(countryCode);
            return list;
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
        
            IList<Flight> list = new List<Flight>();
            list = _flightDAO.GetFlightsByLandingDate(landingDate);
            return list;
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
         
            IList<Flight> list = new List<Flight>();
            list = _flightDAO.GetFlightsByOriginCountry(countryCode);
            return list;
        }

        public IList<AirlineCompanie> GetAllAirlineCompanies()
        {
         
            IList<AirlineCompanie> list = new List<AirlineCompanie>();
            list = _airlineDAO.GetAll();
            return list;
        }

        public Flight GetFlightById(int id)
        {
            Flight flight = new Flight();
            flight=_flightDAO.GetFlightById(id);
            return flight;
        }
        public IList <Country> getAllCountryForSearchList() {
           IList<Country> country = new List<Country>();
            country = _countryDAO.GetAll();
            return country;  
        }
        public IList<AirlineCompanie> getAllAirlineForSearchList()
        {
            IList<AirlineCompanie> airlines = new List<AirlineCompanie>();
            airlines = _airlineDAO.GetAll();
            return airlines;
        }
        public IList<Dal.Customer> getAllCustomersForSearchList()
        {
            IList<Dal.Customer> cast = new List<Dal.Customer>();
            cast = _customerDAO.GetAll();
            return cast;
        }

        public IList<string> getEmailName()
        {
            IList<string> list = new List<string>();
            list = _customerDAO.getOnlyEmail();
            return list;
        }


        public IList<string> getUserNameForAdmin()
        {
            IList<string> list = new List<string>();
            list = _administratorDAO.GetUserName();
            return list;
        }

        public IList<string> getUserPasswordForAdmin()
        {
            IList<string> list = new List<string>();
            list = _administratorDAO.GetPasswords();
            return list;
        }

        public IList<string> getUserNameForAirline()
        {
            IList<string> list = new List<string>();
            list = _airlineDAO.GetUserName();
            return list;
        }

        public IList<string> getUserPasswordForAirline()
        {
            IList<string> list = new List<string>();
            list = _airlineDAO.GetPasswords();
            return list;
        }
        public IList<string> getUserNameForCustomer()
        {
            IList<string> list = new List<string>();
            list = _customerDAO.GetUserName();
            return list;
        }

        public IList<string> getUserPasswordForCustomer()
        {
            IList<string> list = new List<string>();
            list = _customerDAO.GetPasswords();
            return list;
        }
    }
}

