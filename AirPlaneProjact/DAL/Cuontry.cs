using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.Dal
{
    public class Country :IPoco, IUser
    {
        public int _Id { get; set; }
        public string _Country_Name { get; set; }

        public Country() { }

        public Country(string Country_Name)
        {
            _Country_Name = Country_Name;
        }

        #region Overrides 
        public override string ToString()
        {
            return $"Id : {_Id}, Country Name :{_Country_Name}.";
        }

        public override int GetHashCode()
        {
            return _Id;
        }
        public static bool operator ==(Country x, Country y)
        {
            if (x._Id == y._Id)
                return true;
            return false;
        }
        public static bool operator !=(Country x, Country y)
        {
            return !(x._Id == y._Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                Country c = (Country)obj;
                if (c._Id == _Id)
                    return true;
                return false;
            }
        }
        #endregion
    }
}

