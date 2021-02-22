using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;

namespace AirPlaneProjact.DAO
{
    public interface IAirLineDAO :IBasicDB<AirlineCompanie>
    {
        AirlineCompanie GetAirlineByUserName(string name);

        IList<AirlineCompanie> GetAllAirlinesByCountry(int countryId);
         List<string> GetPasswords();
         List<string> GetUserName();
        void ChangePassword(string oldpassword, string newpassword);
    }
}
