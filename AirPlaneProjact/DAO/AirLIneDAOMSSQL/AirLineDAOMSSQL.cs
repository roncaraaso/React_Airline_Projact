using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;

namespace AirPlaneProjact.DAO
{
    public class AirLineDAOMSSQL : IAirLineDAO
    {
        /// <summary>
        /// This class handle connection to D.B of airline table
        /// </summary>
        //Connection String  to database 
        readonly string ConnectionString = new ConfingClass().getConnectionString();
        //adding onc airline company to database
        public void Add(AirlineCompanie t)
        {
            string SqlCommand = "Add_Airline";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"_AirLine_Name", t._AirLine_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_User_Name", t._User_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Password ", t._Password));
                    cmd.Parameters.Add(new SqlParameter(@"_Country_Code", t._Country_Code));
                    cmd.Parameters.Add(new SqlParameter(@"_Email", t._Email));
                    cmd.Parameters.Add(new SqlParameter(@"_First_Name", t._First_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Last_Name", t._Last_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Phone_Number", t._Phone_Number));
                    cmd.Parameters.Add(new SqlParameter(@"_Area_Code", t._Area_Code));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally {
                    cmd.Connection.Close();
                }
            }
        }
    
           //getting one airline from database by id
        public AirlineCompanie Get(int id)
        {
            AirlineCompanie airline = new AirlineCompanie();
            string SqlCommand = "Get_Airline_By_Id";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"id", id));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        airline._Id = (int)reader["Id"];
                        airline._AirLine_Name = (string)reader["AirLine_Name"];
                        airline._User_Name = (string)reader["User_Name"];
                        airline._Password = (string)reader["Password"];
                        airline._First_Name = (string)reader["First_Name"];
                        airline._Last_Name = (string)reader["Last_Name"];
                        airline._Email = (string)reader["Email"];
                        airline._Phone_Number = (int)reader["Phone_Number"];
                        airline._Area_Code = (int)reader["Area_Code"];
                        airline._Country_Code = (int)reader["Country_Code"];
                    }
                    cmd.Connection.Close();
                    return airline;
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
        //geting one airlinr by user name
        public AirlineCompanie GetAirlineByUserName(string name)
        {
            AirlineCompanie airline = new AirlineCompanie();
           
            string SqlCommand = "Get_Air_line_By_User_Name";
            using (SqlConnection con =new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"User_Name", name));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                    while (reader.Read() == true)
                    {
                        airline._Id = (int)reader["Id"];
                        airline._AirLine_Name = (string)reader["AirLine_Name"];
                        airline._User_Name = (string)reader["User_Name"];
                        airline._Password = (string)reader["Password"];
                        airline._First_Name = (string)reader["First_Name"];
                        airline._Last_Name = (string)reader["Last_Name"];
                        airline._Email = (string)reader["Email"];
                        airline._Phone_Number = (int)reader["Phone_Number"];
                        airline._Area_Code = (int)reader["Area_Code"];
                        airline._Country_Code = (int)reader["Country_Code"];
                    }
                    return airline;
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
        //to get all airlines in a list
        public IList<AirlineCompanie> GetAll()
        {
            List<AirlineCompanie> list = new List<AirlineCompanie>();
            string SqlCommand = "Select_aLL_Airline_Companies";
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
                        AirlineCompanie airline = new AirlineCompanie();
                        airline._Id = (int)reader["Id"];
                        airline._AirLine_Name = (string)reader["AirLine_Name"];
                        airline._User_Name = (string)reader["User_Name"];
                        airline._Password = (string)reader["Password"];
                        airline._First_Name = (string)reader["First_Name"];
                        airline._Last_Name = (string)reader["Last_Name"];
                        airline._Email = (string)reader["Email"];
                        airline._Phone_Number = (int)reader["Phone_Number"];
                        airline._Area_Code = (int)reader["Area_Code"];
                        airline._Country_Code = (int)reader["Country_Code"];
                        list.Add(airline);
                    }
                    return list;
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
        //get all airlines by country name
        public IList<AirlineCompanie> GetAllAirlinesByCountry(int countryId)
        {
            List<AirlineCompanie> list = new List<AirlineCompanie>();
            string SqlCommand = "Get_All_Airlines_By_Country";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    cmd.Parameters.Add(new SqlParameter(@"Country_Code", countryId));
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    while (reader.Read() == true)
                    {
                        AirlineCompanie airline = new AirlineCompanie();
                        airline._Id = (int)reader["Id"];
                        airline._AirLine_Name = (string)reader["AirLine_Name"];
                        airline._User_Name = (string)reader["User_Name"];
                        airline._Password = (string)reader["Password"];
                        airline._First_Name = (string)reader["First_Name"];
                        airline._Last_Name = (string)reader["Last_Name"];
                        airline._Email = (string)reader["Email"];
                        airline._Phone_Number = (int)reader["Phone_Number"];
                        airline._Area_Code = (int)reader["Area_Code"];
                        airline._Country_Code = (int)reader["Country_Code"];
                        list.Add(airline);
                    }
                    return list;
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
        //delete one airline from database
        public void Remove(AirlineCompanie t)
        {
            string SqlCommand = "Remove_One_Airline";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"id", t._Id));
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
        //updating one airline 
        public void Update(AirlineCompanie t)
        {
            string SqlCommand = "Update_One_airline";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"id", t._Id));
                    cmd.Parameters.Add(new SqlParameter(@"_AirLine_Name", t._AirLine_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_User_Name", t._User_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Password", t._Password));
                    cmd.Parameters.Add(new SqlParameter(@"_First_Name", t._First_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Last_Name", t._Last_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Email", t._Email));
                    cmd.Parameters.Add(new SqlParameter(@"_Phone_Number", t._Phone_Number));
                    cmd.Parameters.Add(new SqlParameter(@"_Area_Code", t._Area_Code));
                    cmd.Parameters.Add(new SqlParameter(@"_Country_Code", t._Country_Code));
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
        //get list of all passwords for checking
        public List<string> GetPasswords()
        {
            List<string> Password = new List<string>();
            string SqlCommand = "[Select_Passwords_Form_Airline]";
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
        //geting  list of user name for checking
        public List<string> GetUserName()
        {
            List<string> UserName = new List<string>();
            string SqlCommand = "Select_UserName_form_Airline";
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
        //checking password that all ready exist and if true changing the password
        public void ChangePassword(string oldpassword, string newpassword)
        {
            List<string> passWordList = GetPasswords();
            string SqlCommand = "ChangePassword_Airline";
            if (passWordList.Contains(oldpassword) == true)
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(SqlCommand, con);
                    try { 
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"newpassword", newpassword));
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
           
        }
        public void AddWpfRecored(int num)
        {
            string SqlCommand = "addWpfRecoredAirline";
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
