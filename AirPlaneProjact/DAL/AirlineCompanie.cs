using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.Dal
{
   public class AirlineCompanie : IPoco,IUser
    {
        public int     _Id { get; set; }
        public string _First_Name { get; set; }
        public string _Last_Name { get; set; }
        public string _AirLine_Name  { get; set; }
        public string _User_Name    { get; set; }
        public string _Password     { get; set; }
        public int    _Country_Code { get; set; }
        public string _Email { get; set; }
        public int _Phone_Number { get; set; }
        public int _Area_Code { get; set; }
      

        public AirlineCompanie()
        {
        }
        public AirlineCompanie(string userName , string password)
          {
            _User_Name = userName;
            _Password = password;
        }

    public AirlineCompanie( string AirLine_Name , string User_Name,string Password , int Country_Code ,string firstName 
                                ,string lastName , string email , int phoneNumber , int areaCode)
        {
            _AirLine_Name = AirLine_Name;
            _User_Name = User_Name;
            _Password = Password;
            _Country_Code = Country_Code;
            _First_Name = firstName;
            _Last_Name = lastName;
            _Email = email;
            _Phone_Number = phoneNumber;
            _Area_Code = areaCode;
        }


        #region Overrides
        public override string ToString()
        {
            return $"Id : {_Id},Air Line Name :{_AirLine_Name},User Name :{_User_Name},Password :{_Password},Country Code :{_Country_Code} , First name :{_First_Name} " +
                $" ,Last Name : {_Last_Name} , Phone Number: {_Phone_Number}, Email :  {_Email}, Area Code :{_Area_Code}.  "  ;
        }

        public override int GetHashCode()
        {
            return _Id;
        }
        public static bool operator ==(AirlineCompanie x, AirlineCompanie y)
        {
            if (x._Id == y._Id)
                return true;
            return false;
        }
        public static bool operator !=(AirlineCompanie x, AirlineCompanie y)
        {
            return !(x._Id == y._Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                AirlineCompanie air = (AirlineCompanie)obj;
                if (air._Id == _Id)
                    return true;
                return false;

            }
        }
        #endregion
    }
}
