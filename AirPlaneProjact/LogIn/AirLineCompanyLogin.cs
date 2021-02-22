using AirPlaneProjact.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.LogIn
{
    public class AirLineCompanyLogin : IPoco, IUser
    {
        private bool _airlinecompany ;

        public bool GetAirLineCompanyr() { return _airlinecompany; }
        public bool SetAirlinecompany() { return _airlinecompany = true; ; }
    }
}
