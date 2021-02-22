using AirPlaneProjact.DAL;
using AirPlaneProjact.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.LogIn
{
    public class LoginService : ILoginService
    {
        private IAirLineDAO _arilineDAO ;

        private ICustomerDAO _customerADO ;

        private IAdministratorDAO _administratorADO;

        public LoginService()
        {
            _administratorADO = new AdministratorDAOMSSQL();
            _customerADO = new CustomerDAOMMSQL();
            _arilineDAO = new AirLineDAOMSSQL();
        }

       

        public bool TryAdminLogin(string userName, string password, out LoginToken<AdministratorLogin> token)
        {
            token = new LoginToken<AdministratorLogin>();          
            List<string> _listpassword = _administratorADO.GetPasswords();
            List<string> _listusername = _administratorADO.GetUserName();
            if (_listpassword.Contains(password) && _listusername.Contains(userName))
            {
                token.User = new AdministratorLogin();
                token.User.SetAdministrator();
                return true;
            }
            else if (!_listpassword.Contains(password))
            {
                throw new WrongPasswordException();          
            }
            else
            {
                token = null;
                return false;
            }
        }

        public bool TryArilineLogin(string userName, string password, out LoginToken<AirLineCompanyLogin> token)
        {
            token = new LoginToken<AirLineCompanyLogin>(); 
            List<string> _listpassword = _arilineDAO.GetPasswords();
            List<string> _listusername = _arilineDAO.GetUserName();
            if (_listpassword.Contains(password) && _listusername.Contains(userName))
            {
                token.User = new AirLineCompanyLogin();
                token.User.SetAirlinecompany();
                return true;
            }
            else if (_listpassword.Contains(password) && !_listusername.Contains(userName))
            {
                
                throw new WrongPasswordException();
            }
            else
            {
                token = null;
                return false;
            }
            


        }

        public bool TryCustomerLogin(string userName, string password, out LoginToken<CustomerLogin> token)
        {
            token = new LoginToken<CustomerLogin>();        
            List<string> _listpassword = _customerADO.GetPasswords();
            List<string> _listusername =_customerADO.GetUserName();
            if (_listpassword.Contains(password) && _listusername.Contains(userName))
            {
                token.User = new CustomerLogin();
                token.User.SetCustomer();
                return true;
            }
            else if (_listpassword.Contains(password) && !_listusername.Contains(userName))
            {
                
                throw new WrongPasswordException();
            }
            else
            {
                token = null;
                return false;
            }             
               
        }

        public bool TayAllLogin(string userName, string password, out LoginToken<AdministratorLogin> admin,
             LoginToken<AirLineCompanyLogin> airline, LoginToken<CustomerLogin> customer)
        {
            admin = new LoginToken<AdministratorLogin>();
            TryAdminLogin(userName, password, out admin);

            airline = new LoginToken<AirLineCompanyLogin>();
            TryArilineLogin(userName, password, out airline);

            customer = new LoginToken<CustomerLogin>();
            TryCustomerLogin(userName, password, out customer);
            if (admin == null && airline == null && customer == null)
            {
                throw new UserNotFoundException();
            }
            else
            {
                return true;
            }
        }
    }
}
