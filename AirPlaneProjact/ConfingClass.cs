using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact
{
    public class ConfingClass
    {
        private string connectionString = "Data Source =.; DataBase =AirLine; Integrated Security = true;";

        public string getConnectionString()
        {
            return connectionString;
        }
    }
}
