using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.Dal
{
    public class Ticket : IPoco, IUser
    {
       public int _Id { get; set; }
       public int _Flight_Id { get; set; }
       public int _Custumer_Id { get; set; }

        public Ticket()
        {

        }

        public Ticket(int Id, int FlightId, int CustumerId)
        {
            _Id = Id;
            _Flight_Id = FlightId;
            _Custumer_Id = CustumerId;
        }


        #region Overrides
        public override int GetHashCode()
        {
            return _Id;
        }

        public override string ToString()
        {
            return $"Id : {_Id}, Flight Id :{_Flight_Id}, Costumer Id : {_Custumer_Id}";
        }
        public static bool operator ==(Ticket x, Ticket y)
        {
            if (x._Id == y._Id)
                return true;
            return false;
        }
        public static bool operator !=(Ticket x, Ticket y)
        {
            return !(x._Id == y._Id);
        }
        public override bool Equals(object obj)
        {
            if( obj == null)
            {
                return false;
            }
            else
            {
                Ticket t = (Ticket)obj;
                if (t._Id == _Id)
                    return true;
                return false;
            }

        }
        #endregion
    }
}
