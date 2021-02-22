using AirPlaneProjact.Dal;
using AirPlaneProjact.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirPlaneProjact.BLL
{
    public interface ILoggedInCustomerFacade
    {
        IList<Flight> GetAllMyFlights(LoginToken<LogIn.CustomerLogin> token);

        void PurchaseTicket(LoginToken<LogIn.CustomerLogin> token, Ticket ticket);

        void CancelTicket(LoginToken<LogIn.CustomerLogin> token, Ticket ticket);

        Dal.Customer getUserNamecustomer(LoginToken<CustomerLogin> token, string name);

        void updateOneCustomer(LoginToken<CustomerLogin> token, Dal.Customer customer);

        IList<Ticket> GetTicket(LoginToken<CustomerLogin> token, Ticket ticket);

        void updateTicket(Flight flight);

    }
}
