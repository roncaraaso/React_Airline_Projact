using AirPlaneProjact.Dal;
using AirPlaneProjact.DAL;
using AirPlaneProjact.LogIn;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AirPlaneProjact.DAO
{
    public class AdministratorDAOMSSQL : IAdministratorDAO, IPoco, IUser
    {  /// <summary>
       /// This class handle connecttion to D.B of Administrator table
       /// </summary>
        //Connection String  to database 
        string ConnectionString = new ConfingClass().getConnectionString();
   
        // geting one admin
        public void Add(AdministratorDal t)
        {
            string SqlCommand = "Add_One_Administrator";
          
             using (SqlConnection con = new SqlConnection(ConnectionString))
             {
               
                 SqlCommand cmd = new SqlCommand(SqlCommand, con);
                 try
                 {
                     cmd.Connection.Open();
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.Add(new SqlParameter(@"_User_Name", t._User_Name));
                     cmd.Parameters.Add(new SqlParameter(@"_Password", t._Password));
                     cmd.Parameters.Add(new SqlParameter(@"_First_Name", t.First_Name));
                     cmd.Parameters.Add(new SqlParameter(@"_Last_Name", t.Last_Name));
                     cmd.Parameters.Add(new SqlParameter(@"_Email", t.Email));
                     cmd.ExecuteNonQuery();
                     cmd.Connection.Close();
                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
                 finally
                 {
                     cmd.Connection.Close();
                 }
             }
        }
        // get admin by id
        public AdministratorDal Get(int id)
        {
            AdministratorDal admin = new AdministratorDal();
            string SqlCommand = "Get_Administrator_By_Id";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"Administrator_Id", id));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        admin._Id = (int)reader["Id"];
                        admin._User_Name = (string)reader["User_Name"];
                        admin._Password = (string)reader["Password"];
                        admin.First_Name = (string)reader["First_Name"];
                        admin.Last_Name = (string)reader["Last_Name"];
                        admin.Email = (string)reader["Email"];

                    }
                    cmd.Connection.Close();
                    return admin;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }
        //gat all admins
        public IList<AdministratorDal> GetAll()
        {
            List<AdministratorDal> list = new List<AdministratorDal>();
            string SqlCommand = "Select_aLL_Administrator";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        AdministratorDal admin = new AdministratorDal();
                        admin._Id = (int)reader["Id"];
                        admin._User_Name = (string)reader["User_Name"];
                        admin._Password = (string)reader["Password "];
                        admin.First_Name = (string)reader["First_Name"];
                        admin.Last_Name = (string)reader["Last_Name"];
                        admin.Email = (string)reader["Email"];
                        list.Add(admin);
                    }
                    return list;
                }catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }
        //get all password form admin table
        public List<string> GetPasswords()
        {
            List<string> Password = new List<string>();
            string SqlCommand = "Select_Passwords_From_Administrator";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        Password.Add((string)reader["Password"]);
                    }
                    cmd.Connection.Close();
                    return Password;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }
        // get ali user names from admin table 
        public List<string> GetUserName()
        {
            List<string> UserName = new List<string>();
            string SqlCommand = "Select_UserName_form_Administrator";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {

                        UserName.Add((string)reader["User_Name"]);
                    }
                    cmd.Connection.Close();
                    return UserName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
          
        }
        // delete admin from data dase
        public void Remove(AdministratorDal t)
        {
            string SqlCommand = "Remove_One_Administrator";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"id", t.GetHashCode()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }

            }
        }
        //update admin in database
        public void Update(AdministratorDal t)
        {
            string SqlCommand = "Update_One_Administrator";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"id", t._Id));
                    cmd.Parameters.Add(new SqlParameter(@"_User_Name", t._User_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Password", t._Password));
                    cmd.Parameters.Add(new SqlParameter(@"_First_Name", t.First_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Last_Name", t.Last_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Email", t.Email));

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }


        public void AddWpfRecored(int num)
        {
            string SqlCommand = "addWpfRecored";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@number", num));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }
    }
}
