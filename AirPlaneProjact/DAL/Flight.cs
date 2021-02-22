using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.Dal
{
     public class Flight : IPoco, IUser
    {
       public int _Id { get;  set; }
       public int _AirlineCompany_Id { get;  set; }
       public int _Origen_Cuntry_code { get;  set; }
       public int _Destination_Contrey_Code { get;  set; }
       public DateTime _Departure_Time { get;  set; }
       public DateTime _Landing_Time{ get;  set; }
       public int _Remaining_Tikes { get;  set; }

        public Flight()
        {
            
        }
        public Flight(int AirlineConpanyId,int OrigenCuntryCode,int DestinationContryCode, DateTime DepartureTime, DateTime Landing_Time, int RemaingTikets)
        {
            _AirlineCompany_Id = AirlineConpanyId;
            _Origen_Cuntry_code = OrigenCuntryCode;
            _Destination_Contrey_Code = DestinationContryCode;
            _Departure_Time = DepartureTime.Date;
            _Landing_Time = Landing_Time.Date;
            _Remaining_Tikes = RemaingTikets;
        }

      
        #region Overrides
        public override string ToString()
        {
            return $"Id :{_Id}, Airline Company Id :{_AirlineCompany_Id},Origen Cuntry Code :{_Origen_Cuntry_code} '" +
                $"Destination Contry Code : {_Destination_Contrey_Code},DepartureTime :{_Departure_Time},LandingTime :{_Landing_Time} Remaing Tikets {_Remaining_Tikes} ";
        }

        public override int GetHashCode()
        {
            return _Id;
        }
         public static bool operator ==(Flight x, Flight y)
        {
            if (x._Id == y._Id)
                return true;
            return false;
        }
        public static bool operator !=(Flight x, Flight y)
        {
            return !(x._Id == y._Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                Flight f = (Flight)obj;
                if (_Id == f._Id)
                    return true;
                return false;
            }
        }
        #endregion
    }
}
