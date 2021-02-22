using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.Dal
{
    public class Customer : IPoco, IUser
    {
        public int _Id { get; set; }
        public string _First_Name { get; set; }
        public string _Last_Name  { get; set; }
        public string _User_Name   { get; set; }
        public string _Password   { get; set; }
        public string _Address    { get; set; }
        public string _Phone_No  { get; set; }
        public string _Credit_Card_Number { get; set; }
        public string _Email { get; set; } 

        public Customer()
        {
        }
        public Customer(string userName , string password)
        {
            _Password = password;
            _User_Name = userName;
        }
        public Customer(string FirstName, string LastName,string UserName, string Password, string Address,
            string PhoneNo, string CreditCardNumber ,string email)
        {
           
            _First_Name = FirstName;
            _Last_Name = LastName;
            _User_Name = UserName;
            _Password = Password;
            _Address = Address;
            _Phone_No = PhoneNo;
            _Credit_Card_Number = CreditCardNumber;
            _Email = email;
        }

     
    


        #region Override
        public override string ToString()
        {
            return $"Id :{_Id} ,First Name :{_First_Name},Last Name{_Last_Name},User Name:{_User_Name}," +
                $"Password:{_Password},Address:{_Address},PhoneNo:{_Address}," +
                $"Credit Card Number:{_Credit_Card_Number}  Email :{_Email}" ;
        }

        public override int GetHashCode()
        {
            return _Id;
        }
        public static bool operator ==(Customer x, Customer y)
        {
            if (x._Id == y._Id)
                return true;
            return false;
        }
        public static bool operator !=(Customer x, Customer y)
        {
            return !(x._Id == y._Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                Customer c = (Customer)obj;
                if (c._Id == _Id)
                    return true;
                return false;
            }
        }
        #endregion
    }
}

