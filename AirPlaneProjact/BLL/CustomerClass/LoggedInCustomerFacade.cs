using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;
using AirPlaneProjact.DAO;
using AirPlaneProjact.LogIn;

namespace AirPlaneProjact.BLL.Customer
{
    public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade
    {/// <summary>
     /// This class handle connecttion to Dao  custoner functions
     /// </summary>
     /// <param name="token"></param>
     /// <param name="ticket"></param>
        public void CancelTicket(LoginToken<CustomerLogin> token, Ticket ticket)
        {
            if (token.User.GetCustomer()) _ticketDAO.Remove(ticket); 
        }

        public IList<Flight> GetAllMyFlights(LoginToken<CustomerLogin> token)
        {
            IList<Flight> list = new List<Flight>();
            _flightDAO = new FlightDAOMSSQL();
            if (token.User.GetCustomer())
            {
                list = _flightDAO.GetAll();
                return list;
            }
            else
                return null;
        }
      public void PurchaseTicket(LoginToken<LogIn.CustomerLogin> token, Ticket ticket)

        { 
            if (token.User.GetCustomer())
            {
                
                _ticketDAO.Add(ticket);

            }
    

        }
        public Dal.Customer getUserNamecustomer(LoginToken<CustomerLogin> token,string name)
        {
            if (token.User.GetCustomer())
            {
                Dal.Customer customer = new Dal.Customer();
                customer = _customerDAO.GetCustomerByUserName(name);
                return customer;
            }
            else { return null; }
        }
        public void updateOneCustomer(LoginToken<CustomerLogin> token, Dal.Customer customer)
        {
            if (token.User.GetCustomer())
            {
           _customerDAO.Update(customer); ;
            }
        }
        public IList<Ticket> GetTicket(LoginToken<CustomerLogin> token, Ticket ticket)
        {
            IList<Ticket> list = new List<Ticket>();
            if (token.User.GetCustomer())
            {
                list = _ticketDAO.GetAll();
               return list  ;
            }
            return null;
        }
        public void updateTicket(LoginToken<CustomerLogin> token ,Flight flight)
        {
            _flightDAO.UpdateTicketsFlight(flight);
        }

        public void updateTicket(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
