using AirPlaneProjact.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.LogIn
{
    public class CustomerLogin :IPoco,IUser
    {
        private bool _customer ;

        public bool GetCustomer() { return _customer; }
        public bool SetCustomer() { return _customer = true;  }
    }
}
