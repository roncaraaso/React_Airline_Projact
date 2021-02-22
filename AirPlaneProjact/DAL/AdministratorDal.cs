using AirPlaneProjact.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlaneProjact.DAL
{
    public class AdministratorDal : IPoco,IUser
    {
        public int _Id { get; set; }
        public string _User_Name { get; set; }
        public string _Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }

        public AdministratorDal() { }

        public AdministratorDal(string userName , string password)
        {
            _User_Name = userName;
            _Password = password;
        }



        #region Overrides
        public override string ToString()
        {
            return $" Id : {_Id}, User_Name :{_User_Name}, Password :{_Password} ,First Name{First_Name} , Last Name{Last_Name} , Email{Email}. ";
        }

        public override int GetHashCode()
        {
            return _Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            } else
            {
                AdministratorDal admin = obj as AdministratorDal;
                if (admin._Id == _Id)
                    return true;
                return false;
            }  
        }

        public static bool operator ==(AdministratorDal x ,AdministratorDal y)
        {
            if (x._Id == y._Id)
                return true;
                return false;
        }
        public static bool operator !=(AdministratorDal x, AdministratorDal y)
        {
            return !(x._Id == y._Id);
        }

        #endregion
    }
}
