using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;

namespace AirPlaneProjact.DAO
{
    public interface ICustomerDAO:IBasicDB<Customer>
    {
        Customer GetCustomerByUserName(string name);
        List<string> GetPasswords();

        List<string> GetUserName();
        List<string> getOnlyEmail();
    }
}
