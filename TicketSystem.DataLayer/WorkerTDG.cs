using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DataLayer
{
    public class WorkerTDG
    {
        public DataTable GetAll()
        {
            string query = $"SELECT* FROM WORKER";
            var result = new DataTable();
            var connString = DBConnector.GetBuilder();
            using (SqlConnection connection = new SqlConnection(connString.ToString()))
            {
                // Open connection
                connection.Open();

                // prepare command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // execute command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // read data from result
                        result.Load(reader);
                    }
                }
            }
            return result;
        }
        public DataTable GetByName(string name)
        {
            string query = $"SELECT* FROM WORKER WHERE name = '{name}'";
            var result = new DataTable();
            var connString = DBConnector.GetBuilder();
            using (SqlConnection connection = new SqlConnection(connString.ToString()))
            {
                // Open connection
                connection.Open();

                // prepare command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // execute command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // read data from result
                        result.Load(reader);
                    }
                }
            }
            return result;
        }
        public DataTable GetStationByUsername(string name)
        {
            string query = $"select* from Worker join Station_Worker on Worker.worker_id = Station_Worker.worker_id join Station on Station_Worker.station_id = Station.station_id where Worker.name = '{name}'";
            var result = new DataTable();
            var connString = DBConnector.GetBuilder();
            using (SqlConnection connection = new SqlConnection(connString.ToString()))
            {
                // Open connection
                connection.Open();

                // prepare command
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // execute command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // read data from result
                        result.Load(reader);
                    }
                }
            }
            return result;
        }
    }
}
