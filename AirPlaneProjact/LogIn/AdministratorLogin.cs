using AirPlaneProjact.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.LogIn
{
    public class AdministratorLogin :IUser
    {
        private bool _administrator ;  

        public bool GetAdministrator() { return _administrator; }
        public bool SetAdministrator() { return _administrator = true; }
       
    }
}
