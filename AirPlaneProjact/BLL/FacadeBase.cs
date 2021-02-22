using AirPlaneProjact.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.BLL
{
   public abstract class FacadeBase
    {
        protected IAirLineDAO _airlineDAO ;

        protected ICountryDAO _countryDAO;

        protected ICustomerDAO _customerDAO;

        protected IFlightDAO _flightDAO;

        protected ITicketDAO _ticketDAO;

        protected IAdministratorDAO _administratorDAO;
    }
}
