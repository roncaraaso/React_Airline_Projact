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
    public  class TicketDAOMSSQL : ITicketDAO
    {
        /// <summary>
        /// This class handle connecttion to D.B of ticket table
        /// </summary>
        //Connection String  to database 
        string ConnectionString = new ConfingClass().getConnectionString();

        // add one ticket
        public void Add(Ticket t)
        {
            string SqlCommand = "Add_Ticket";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"Flight_Id", t._Flight_Id));
                    cmd.Parameters.Add(new SqlParameter(@"Custumer_Id", t._Custumer_Id));
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
        //get one ticket
        public Ticket Get(int id)
        {
            Ticket tickets = new Ticket();
            string SqlCommand = "Get_Ticket_By_Id";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"Id", id));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        tickets._Id = (int)reader["Id"];
                        tickets._Flight_Id = (int)reader["Flight_Id"];
                        tickets._Custumer_Id = (int)reader["Custumer_Id"];
                    }
                    return tickets;
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

        //get all tickets
        public IList<Ticket> GetAll()
        {
            List<Ticket> list = new List<Ticket>();
            string SqlCommand = "Select_All_Tickets ";
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
                        Ticket ticket = new Ticket();
                        ticket._Id = Convert.ToInt32(reader["Id"]);
                        ticket._Flight_Id = Convert.ToInt32(reader["Flight_Id"]);
                        ticket._Custumer_Id = Convert.ToInt32(reader["Custumer_Id"]);
                        list.Add(ticket);
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
        //delete all tickets
        public void Remove(Ticket t)
        {
            string SqlCommand = "Remove_One_Ticket";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"id ", t._Id));
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
        // update one ticket
        public void Update(Ticket t)
        {
            string SqlCommand = "Update_Cuontry_By_Id";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"id", t._Id));
                    cmd.Parameters.Add(new SqlParameter(@"Flight_Id", t._Flight_Id));
                    cmd.Parameters.Add(new SqlParameter(@"Custumer_Id", t._Custumer_Id));
                    cmd.Connection.Open();
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

        public void AddWpfRecored(int num)
        {
            Random rend = new Random();
            int randomNumber = rend.Next(0, num);
            string SqlCommand = "addWpfRecoredTickets";
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
    }
}
