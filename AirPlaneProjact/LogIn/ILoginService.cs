using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;
using AirPlaneProjact.DAL;

namespace AirPlaneProjact.LogIn
{
    public interface ILoginService
    {
        bool TryAdminLogin(string userName, string password, out LoginToken<AdministratorLogin> token);

        bool TryCustomerLogin(string userName, string password, out LoginToken<CustomerLogin> token);

        bool TryArilineLogin(string userName, string password, out LoginToken<AirLineCompanyLogin> token);

    }
}
