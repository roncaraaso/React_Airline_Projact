using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPlaneProjact.Dal;
using System.Configuration;


namespace AirPlaneProjact.DAO
{
    public class FlightDAOMSSQL : IFlightDAO
    {  /// <summary>
       /// This class handle connecttion to D.B of flight table
       /// </summary>
        //Connection String  to database 
        readonly string ConnectionString = new ConfingClass().getConnectionString();

             // add one flight
            public void Add(Flight t)
        {
            string SqlCommand = "Add_Flight";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"Airline_Id", t._AirlineCompany_Id));
                    cmd.Parameters.Add(new SqlParameter(@"Origen_Cuntry_code", t._Origen_Cuntry_code));
                    cmd.Parameters.Add(new SqlParameter(@"Destination_Contrey_Code", t._Destination_Contrey_Code));
                    cmd.Parameters.Add(new SqlParameter(@"Departure_Time", t._Departure_Time));
                    cmd.Parameters.Add(new SqlParameter(@"Landing_Time", t._Landing_Time));
                    cmd.Parameters.Add(new SqlParameter(@"Remaining_Tikes", t._Remaining_Tikes));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

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


        //get all flights
        public IList<Flight> GetAll()
        {

            List<Flight> list = new List<Flight>();
            string SqlCommand = "Select_All_Flights";
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
                        Flight flight = new Flight();
                        flight._Id = (int)reader["Id"];
                        flight._AirlineCompany_Id = (int)reader["AirlineCompany_Id"];
                        flight._Origen_Cuntry_code = (int)reader["Origen_Cuntry_code"];
                        flight._Destination_Contrey_Code = (int)reader["Destination_Contrey_Code"];
                        flight._Departure_Time = (DateTime)reader["Departure_Time"];
                        flight._Landing_Time = (DateTime)reader["Landing_Time"];
                        flight._Remaining_Tikes = (int)reader["Remaining_Tikes"];
                        list.Add(flight);
                    }
                    return list;
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
        //Get all  flights vacancy
        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {

            string SqlCommand = "GetAllFlightsVacancy";
            Dictionary<Flight, int> dic = new Dictionary<Flight, int>();
            int num = 0;
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
                        if ((int)reader["Remaining_Tikes"] != 0)
                        {
                            Flight flight = new Flight
                            {
                                _Id = (int)reader["Id"],
                                _AirlineCompany_Id = (int)reader["AirlineCompany_Id"],
                                _Origen_Cuntry_code = (int)reader["Origen_Cuntry_code"],
                                _Destination_Contrey_Code = (int)reader["Destination_Contrey_Code"],
                                _Departure_Time = (DateTime)reader["Departure_Time"],
                                _Landing_Time = (DateTime)reader["Landing_Time"],
                                _Remaining_Tikes = (int)reader["Remaining_Tikes"]
                            };
                            dic.Add(flight, flight._Remaining_Tikes);
                            num++;
                        }
                    }
                    return dic;
                } catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }


        }
        // get flight by id
        public Flight GetFlightById(int id) 
        {
        Flight flight = new Flight();
            string SqlCommand = "Get_Flight_ById";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"Id", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        flight._Id = (int)reader["Id"];
                        flight._AirlineCompany_Id = (int)reader["AirlineCompany_Id"];
                        flight._Origen_Cuntry_code = (int)reader["Origen_Cuntry_code"];
                        flight._Destination_Contrey_Code = (int)reader["Destination_Contrey_Code"];
                        flight._Departure_Time = (DateTime)reader["Departure_Time"];
                        flight._Landing_Time = (DateTime)reader["Landing_Time"];
                        flight._Remaining_Tikes = (int)reader["Remaining_Tikes"];
                    }
                    return flight;
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
        // get flight by customer
        public IList<Flight> GetFlightsByCustomer(Customer customer)
        {

            string SqlCommand = "GetFlightsByCustomer";
            List<Flight> list = new List<Flight>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"Customer", customer.GetHashCode()));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        Flight flight = new Flight
                        {
                            _Id = (int)reader["Id"],
                            _AirlineCompany_Id = (int)reader["AirlineCompany_Id"],
                            _Origen_Cuntry_code = (int)reader["Origen_Cuntry_code"],
                            _Destination_Contrey_Code = (int)reader["Destination_Contrey_Code"],
                            _Departure_Time = (DateTime)reader["Departure_Time"],
                            _Landing_Time = (DateTime)reader["Landing_Time"],
                            _Remaining_Tikes = (int)reader["Remaining_Tikes"]
                        };
                        list.Add(flight);
                    }
                    return list;
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
        // get flights by departrure date
        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {

            string SqlCommand = "GetFlightsByDepatrureDate";
            List<Flight> list = new List<Flight>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"DepatrureDate", departureDate));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        Flight flight = new Flight
                        {
                            _Id = (int)reader["Id"],
                            _AirlineCompany_Id = (int)reader["AirlineCompany_Id"],
                            _Origen_Cuntry_code = (int)reader["Origen_Cuntry_code"],
                            _Destination_Contrey_Code = (int)reader["Destination_Contrey_Code"],
                            _Departure_Time = (DateTime)reader["Departure_Time"],
                            _Landing_Time = (DateTime)reader["Landing_Time"],
                            _Remaining_Tikes = (int)reader["Remaining_Tikes"]
                        };
                        list.Add(flight);
                    }
                    return list;
                } catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }

        }
        // get flights by destination country
        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {

            string SqlCommand = "GetFlightsByDestinationCountry";
            List<Flight> list = new List<Flight>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"DestinationCountry", countryCode));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        Flight flight = new Flight
                        {
                            _Id = (int)reader["Id"],
                            _AirlineCompany_Id = (int)reader["AirlineCompany_Id"],
                            _Origen_Cuntry_code = (int)reader["Origen_Cuntry_code"],
                            _Destination_Contrey_Code = (int)reader["Destination_Contrey_Code"],
                            _Departure_Time = (DateTime)reader["Departure_Time"],
                            _Landing_Time = (DateTime)reader["Landing_Time"],
                            _Remaining_Tikes = (int)reader["Remaining_Tikes"]
                        };
                        list.Add(flight);
                    }
                    return list;
                } catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }

        }
        // fet all flights by landing time
        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {

            string SqlCommand = "GetFlightsByLandingDate";
            List<Flight> list = new List<Flight>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"LandingDate", landingDate));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        Flight flight = new Flight
                        {
                            _Id = (int)reader["Id"],
                            _AirlineCompany_Id = (int)reader["AirlineCompany_Id"],
                            _Origen_Cuntry_code = (int)reader["Origen_Cuntry_code"],
                            _Destination_Contrey_Code = (int)reader["Destination_Contrey_Code"],
                            _Departure_Time = (DateTime)reader["Departure_Time"],
                            _Landing_Time = (DateTime)reader["Landing_Time"],
                            _Remaining_Tikes = (int)reader["Remaining_Tikes"]
                        };
                        list.Add(flight);
                    }
                    return list;
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
          // get all flight by origin country
        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {

            string SqlCommand = "GetFlightsByOriginCountry";
            List<Flight> list = new List<Flight>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter(@"OriginCountry", countryCode));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        Flight flight = new Flight
                        {
                            _Id = (int)reader["Id"],
                            _AirlineCompany_Id = (int)reader["AirlineCompany_Id"],
                            _Origen_Cuntry_code = (int)reader["Origen_Cuntry_code"],
                            _Destination_Contrey_Code = (int)reader["Destination_Contrey_Code"],
                            _Departure_Time = (DateTime)reader["Departure_Time"],
                            _Landing_Time = (DateTime)reader["Landing_Time"],
                            _Remaining_Tikes = (int)reader["Remaining_Tikes"]
                        };
                        list.Add(flight);
                    }
                    return list;
                } catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }

        }
         //delete one flight
        public void Remove(Flight t)
        {

            string SqlCommand = "Remove_One_flight";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter(@"id", t._Id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
               
                } catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }
        //update one flight 
        public void Update(Flight t)
        {

            string SqlCommand = "Update_One_Flihgt";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Parameters.Add(new SqlParameter(@"id", t._Id));
                    cmd.Parameters.Add(new SqlParameter(@"AirlineCompany_Id", t._AirlineCompany_Id));
                    cmd.Parameters.Add(new SqlParameter(@"Origen_Cuntry_code", t._Origen_Cuntry_code));
                    cmd.Parameters.Add(new SqlParameter(@"Destination_Contrey_Code", t._Destination_Contrey_Code));
                    cmd.Parameters.Add(new SqlParameter(@"Departure_Time", t._Departure_Time));
                    cmd.Parameters.Add(new SqlParameter(@"Landing_Time", t._Landing_Time));
                    cmd.Parameters.Add(new SqlParameter(@"Remaining_Tikes", t._Remaining_Tikes));

                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
            
                } catch (Exception ex)
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
            string SqlCommand = "addWpfRecoredFlihgts";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@number", num));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
             
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
        //update tickets  flights
        public void UpdateTicketsFlight(Flight t)
        {
            string SqlCommand = "Update_Tickets_Flight";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(SqlCommand, con);
                try
                {
                    cmd.Parameters.Add(new SqlParameter(@"id", t._Id));
                    cmd.Parameters.Add(new SqlParameter(@"Remaining_Tikes", t._Remaining_Tikes));

                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
              
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

        public Flight Get(int id)
        {
            throw new NotImplementedException();
        }
  
    }
    
    
}
