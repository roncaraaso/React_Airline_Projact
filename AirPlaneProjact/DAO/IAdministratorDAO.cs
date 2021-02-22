using AirPlaneProjact.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.DAO
{
    public  interface IAdministratorDAO:IBasicDB<AdministratorDal>
    {
        List<string> GetPasswords();
        List<string> GetUserName();
    }
}
