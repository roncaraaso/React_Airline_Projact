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
    class CustomerDAOMMSQL : ICustomerDAO

    {
        /// <summary>
        /// This class handle connecttion to D.B of customer table
        /// </summary>
        //Connection String  to database 
        string ConnectionString = new ConfingClass().getConnectionString();
        //add one customer to D.B
        public void Add(Customer t)
        {
            string SqlCommand = "Add_customer";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"_First_Name", t._First_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Last_Name", t._Last_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_User_Name", t._User_Name));
                    cmd.Parameters.Add(new SqlParameter(@"_Password", t._Password));
                    cmd.Parameters.Add(new SqlParameter(@"_Address", t._Address));
                    cmd.Parameters.Add(new SqlParameter(@"_Phone_No", t._Phone_No));
                    cmd.Parameters.Add(new SqlParameter(@"_Email", t._Email));
                    cmd.Parameters.Add(new SqlParameter(@"_Credit_Card_Number", t._Credit_Card_Number));
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
        //geting one customer by id from D.>B
        public Customer Get(int id)
        {
            Customer cust = new Customer();
            string SqlCommand = "Get_customer_By_Id";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"cuontryId", id));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        cust._Id = (int)reader["Id"];
                        cust._First_Name = (string)reader["First_Name"];
                        cust._Last_Name = (string)reader["Last_name"];
                        cust._User_Name = (string)reader["_User_Name"];
                        cust._Password = (string)reader["Password"];
                        cust._Address = (string)reader["Address"];
                        cust._Phone_No = (string)reader["Phone_No"];
                        cust._Email = (string)reader["Email"];
                        cust._Credit_Card_Number = (string)reader["Credit_Card_Number"];

                    }
                    cmd.Connection.Close();
                    return cust;
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
        //geting all customers to list from D.B
        public IList<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();
            string SqlCommand = "Select_aLL_customres";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try { 
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Customer cust = new Customer();
                    cust._Id = (int)reader["Id"];
                    cust._First_Name = (string)reader["First_Name"];
                    cust._Last_Name = (string)reader["Last_name"];
                    cust._User_Name = (string)reader["User_Name"];
                    cust._Password = (string)reader["Password"];
                    cust._Address = (string)reader["Address"];
                    cust._Phone_No = (string)reader["Phone_No"];
                    cust._Email = (string)reader["Email"];
                    cust._Credit_Card_Number = (string)reader["Credit_Card_Number"];
                    list.Add(cust);
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

        //get customer by user name
        public Customer GetCustomerByUserName(string name)
        {
           // string SqlCommand = " Get_Customer_By_User_Name";
            Customer cust = new Customer();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Customers where User_Name = @User_Name;", con);
                try
                {
                    cmd.Connection.Open();
                    // cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"User_Name", name));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                    while (reader.Read() == true)
                    {
                        cust._Id = (int)reader["Id"];
                        cust._First_Name = (string)reader["First_Name"];
                        cust._Last_Name = (string)reader["Last_name"];
                        cust._User_Name = (string)reader["User_Name"];
                        cust._Password = (string)reader["Password"];
                        cust._Address = (string)reader["Address"];
                        cust._Phone_No = (string)reader["Phone_No"];
                        cust._Email = (string)reader["Email"];
                        cust._Credit_Card_Number = (string)reader["Credit_Card_Number"];
                    }
                    return cust;
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
        //delete one customer 
        public void Remove(Customer t)
        {
            string SqlCommand = "Remove_One_customer";

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
        
        //update one customer 
        public void Update(Customer t)
        {
            string SqlCommand = "Update_One_Customer";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try { 
                cmd.Parameters.Add(new SqlParameter(@"id", t._Id));
                cmd.Parameters.Add(new SqlParameter(@"_First_Name", t._First_Name));
                cmd.Parameters.Add(new SqlParameter(@"_Last_Name", t._Last_Name));
                cmd.Parameters.Add(new SqlParameter(@"_User_Name", t._User_Name));
                cmd.Parameters.Add(new SqlParameter(@"_Password", t._Password));
                cmd.Parameters.Add(new SqlParameter(@"_Address", t._Address));
                cmd.Parameters.Add(new SqlParameter(@"_Phone_No", t._Phone_No));
                cmd.Parameters.Add(new SqlParameter(@"_Email", t._Email));
                cmd.Parameters.Add(new SqlParameter(@"_Credit_Card_Number", t._Credit_Card_Number));
                cmd.CommandType = CommandType.StoredProcedure;
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
     //   get list of  customer password
        public List<string> GetPasswords()
        {
            List<string> Password = new List<string>();
            string SqlCommand = "Select_Passwords_From_Customer";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try { 
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    Password.Add((string)reader["Password"]);
                }
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
       //get user name of all customers
        public List<string> GetUserName()
        {
            List<string> UserName = new List<string>();
            string SqlCommand = "Select_UserName_form_Customer";
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
        public void AddWpfRecored(int num)
        {
            Random rend = new Random();
            int randomNumber = rend.Next(0, num);
            string SqlCommand = "addWpfRecoredCostumer";
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(SqlCommand, con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@number", randomNumber));
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
        public List<string> getOnlyEmail()
        {

            List<string> list = new List<string>();
            string SqlCommand = "getOnlyEmail";
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

                        list.Add((string)reader["Email"]);
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
    }
}
