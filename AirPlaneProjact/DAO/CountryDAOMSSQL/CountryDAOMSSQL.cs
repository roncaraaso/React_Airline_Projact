using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AirPlaneProjact.DAO.CountryDAOMSSQL
{
     public class CountryDAOMSSQL : ICountryDAO
    {  /// <summary>
       /// This class handle connecttion to D.B of country table
       /// </summary>
        //Connection String  to database 
        readonly string ConnectionString = new ConfingClass().getConnectionString();
       
        // adding one country to database
        public void Add(Country t)
        {
            string SqlCommand = "Add_Country";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"_Country_Name", t._Country_Name));
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
        // geting country from database by id
        public Country Get(int id)
        {
            Country country = new Country();
            string SqlCommand = "Get_Cuontry_By_Id";
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
                        country._Id = (int)reader["Id"];
                        country._Country_Name = (string)reader["Country_Name"];

                    }
                    cmd.Connection.Close();
                    return country;
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
        // geting all countries from database
        public IList<Country> GetAll()
        {
            List<Country> list = new List<Country>();
            string SqlCommand = "Select_All_cuontries";
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
                        Country cuontry = new Country();
                        cuontry._Id = (int)reader["Id"];
                        cuontry._Country_Name = (string)reader["Country_Name"];
                        list.Add(cuontry);
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
        //delete one country from database
        public void Remove(Country t)
        {
            string SqlCommand = "Remove_One_Cuontry";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand,con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"cuontryId", t._Id));
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
        //update one country to the database
        public void Update(Country t)
        {
            string SqlCommand = "Update_Cuontry_By_Id";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try { 
                cmd.Parameters.Add(new SqlParameter(@"id", t._Id));
                cmd.Parameters.Add(new SqlParameter(@"name", t._Country_Name));
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
        public void AddWpfRecored(int num)
        {
            string SqlCommand = "addWpfRecoredCountry";
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
